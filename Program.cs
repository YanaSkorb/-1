using System;

namespace задание_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Programms prog = new Programms(new OpProgramState());
            prog.Open();
            prog.Open();
            prog.Open();
            prog.Close();
            prog.Close();
            prog.Close();    

            Console.Read();
        }
    }
    class Programms
    {
        public IProgramState State { get; set; }

        public Programms(IProgramState ps)
        {
            State = ps;
        }

        public void Open()
        {
            State.Open(this);
        }
        public void Close()
        {
            State.Close(this);
        }
    }
    interface IProgramState
    {
        void Open(Programms progs);
        void Close(Programms progs);
    }

    class ExpProgramState : IProgramState
    {
        public void Open(Programms progs)
        {
            Console.WriteLine("Нажимаем Открыть программу");
            progs.State = new OpProgramState();
        }

        public void Close(Programms progs)
        {
            Console.WriteLine("нажимаем на кнопку Закрыть программу");
        }
    }
    class OpProgramState : IProgramState
    {
        public void Open(Programms progs)
        {
            Console.WriteLine("Ожидаем загрузку программы");
            progs.State = new ClProgrState();
        }

        public void Close(Programms progs)
        {
            Console.WriteLine("Ожидаем закрытие программы");
            progs.State = new ExpProgramState();
        }
    }
    class ClProgrState : IProgramState
    {
        public void Open(Programms progs)
        {
            Console.WriteLine("Успешное открытие программы");
        }
        public void Close(Programms progs)
        {
            Console.WriteLine("Закрытие программы");
            progs.State = new OpProgramState();
        }
    }
}
