using CommandCenter.Messages;
using CommandCenter.Models;
using CommandCenter.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RoboDk.API;
using RoboDk.API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CommandCenter.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject, IRecipient<ProgramDetailsMessage>, IRecipient<IODetailsMessage>, IRecipient<TargetDetailsMessage>
    {
        public RoboDK activeStation;

        [ObservableProperty]
        ViewWrapper wrapper;

        [ObservableProperty]
        Target? selectedTarget;

        [ObservableProperty]
        object selectedProgramObject;

        public MainPageViewModel()
        {
            activeStation = new RoboDK();
            wrapper = new ViewWrapper(activeStation);

            WeakReferenceMessenger.Default.Register<ProgramDetailsMessage>(this);
            WeakReferenceMessenger.Default.Register<IODetailsMessage>(this);
            WeakReferenceMessenger.Default.Register<TargetDetailsMessage>(this);

            IRoboDKEventSource source = activeStation.OpenRoboDkEventChannel();
        }

        #region Commands 

        [RelayCommand]
        void CreateTarget()
        {
            CreateTargetWindow view = new();
            WeakReferenceMessenger.Default.Send(new RobotListMessage(Wrapper.Robots));
            view.ShowDialog();
    
        }

        [RelayCommand]
        void Update() => Wrapper.Update();

        [RelayCommand]
        void AddTargetToProgram()
        {
            if (SelectedTarget != null)
                Wrapper.Program.Add(SelectedTarget);    
        }

        [RelayCommand]
        void DeleteSelected()
        {
            if (SelectedProgramObject == null)
                return;

            Wrapper.Program.Remove(SelectedProgramObject);
        }

        [RelayCommand]
        void CreateProgramDialog()
        {
            CreateProgramWindow view = new CreateProgramWindow();
            WeakReferenceMessenger.Default.Send(new RobotListMessage(Wrapper.Robots));
            view.ShowDialog();
        }

        [RelayCommand]
        void AddIO()
        {
            CreateIOWindow view = new CreateIOWindow();

            view.ShowDialog();
        }

        [RelayCommand]
        void SelectedUp()
        {
            if (SelectedProgramObject == null)
                return;

            object temp = SelectedProgramObject;
            int indexSelected = Wrapper.Program.IndexOf(SelectedProgramObject);

            if(indexSelected-1 >= 0)
            {
                Wrapper.Program[indexSelected] = Wrapper.Program[indexSelected - 1];
                Wrapper.Program[indexSelected - 1] = temp;
            }

            SelectedProgramObject = temp;
        }

        [RelayCommand]
        void SelectedDown()
        {

            if (SelectedProgramObject == null)
                return;

            object temp = SelectedProgramObject;
            int indexSelected = Wrapper.Program.IndexOf(SelectedProgramObject);

            if (indexSelected + 1 < Wrapper.Program.Count)
            {
                Wrapper.Program[indexSelected] = Wrapper.Program[indexSelected + 1];
                Wrapper.Program[indexSelected + 1] = temp;
            }

            SelectedProgramObject = temp;
        }

        [RelayCommand]
        void DeleteProgram()
        {
            Wrapper.Program.Clear();
        }

        #endregion

        public void Receive(ProgramDetailsMessage message)
        {
            IItem createdProgram = activeStation.AddProgram(message.Value.ProgramName, message.Value.LinkedRobot);

            foreach (object item in Wrapper.Program)
            {
                if (item is Target temp)
                {
                    createdProgram.AddMoveJ(temp.TargetItem);
                }

                if (item is IO io)
                {
                    if (io.iotype == IO.IOType.DO)
                    {
                        createdProgram.setDO(io.Name, io.Value);
                    }
                    else if(io.iotype == IO.IOType.WaitDI)
                    {
                        createdProgram.waitDI(io.Name, io.Value, io.Timeout);
                    }
                    else if(io.iotype == IO.IOType.AO)
                    {
                        MessageBox.Show("AO Implementation not found in API");
                    }
                }
            }
        }

        public void Receive(IODetailsMessage message)
        {
            Wrapper.iOs.Add(message.Value);
            Wrapper.Program.Add(message.Value);
        }

        public void Receive(TargetDetailsMessage message)
        {
            activeStation.AddTarget(message.Value.Name, message.Value.linkedrobot.Parent(), message.Value.linkedrobot);
            Wrapper.Update();
        }
    }
}
