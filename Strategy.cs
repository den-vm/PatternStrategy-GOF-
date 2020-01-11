using System;
using System.Threading;
using System.Threading.Tasks;

namespace Strategy
{
    internal interface IMob
    {
        string Name { get; set; }
        int Force { get; set; }
    }

    internal interface IAction
    {
        void DoAction();
        void UndoAction();
    }

    internal interface IMove
    {
        void MoveForward();
        void MoveBack();
        void MoveLeft();
        void MoveRight();
    }

    internal interface IAttack
    {
        void AttackOverhand();
        void AttackBelow();
        void AttackLeftward();
        void AttackRightward();
        void AttackOverhandDownJump();
        void AttackDirect();
    }

    /// <summary>
    /// Движение
    /// </summary>
    internal class MoveAction : IAction
    {
        /// <summary>
        /// реализация - на основании чего должно быть выполнено движение
        /// </summary>
        public void DoAction()
        {
            Console.WriteLine("Применить движение");
        }

        /// <summary>
        /// реализация - на основании чего должно быть отменено движение
        /// </summary>
        public void UndoAction()
        {
            
            Console.WriteLine("Отменить движение");
        }
    }

    /// <summary>
    /// Атака
    /// </summary>
    internal class AttackAction : IAction
    {
        /// <summary>
        /// реализация - на основании чего должна быть выполнена атака
        /// </summary>
        public void DoAction()
        {
            Console.WriteLine("Применить атаку");
        }

        /// <summary>
        /// реализация - на основании чего должна быть отменена атака
        /// </summary>
        public void UndoAction()
        {
            Console.WriteLine("Отменить атаку");
        }
    }

    /// <summary>
    /// Уровневый босс
    /// </summary>
    internal class BoneReaper : IMob, IMove, IAttack
    {
        private readonly IAction attackAction;
        private readonly IAction moveAction;

        public string Name { get; set; }
        public int Force { get; set; }

        public BoneReaper()
        {
            moveAction = new MoveAction();
            attackAction = new AttackAction();
        }

        #region Реализация действий конкретного моба

        public async void MoveBack()
        {
            moveAction.DoAction();
            Console.WriteLine("->Двигаемся назад");
            await Task.Run(() => {
                Thread.Sleep(2000);
                moveAction.UndoAction();
                Console.WriteLine("->Остановка движения назад");
            });
        }
        public async void MoveForward()
        {
            moveAction.DoAction();
            Console.WriteLine("->Двигаемся вперёд");
            await Task.Run(() => {
                Thread.Sleep(2000);
                moveAction.UndoAction();
                Console.WriteLine("->Остановка движения вперёд");
            });
        }
        public async void MoveLeft()
        {
            moveAction.DoAction();
            Console.WriteLine("->Двигаемся влево");
            await Task.Run(() => {
                Thread.Sleep(2000);
                moveAction.UndoAction();
                Console.WriteLine("->Остановка движения влево");
            }); 
        }
        public async void MoveRight()
        {
            moveAction.DoAction();
            Console.WriteLine("->Двигаемся вправо");
            await Task.Run(() => {
                Thread.Sleep(2000);
                moveAction.UndoAction();
                Console.WriteLine("->Остановка движения вправо");
            }); 
        }
        public async void AttackBelow()
        {
            attackAction.DoAction();
            Console.WriteLine("->Атакуем снизу");
            await Task.Run(() => {
                Thread.Sleep(2000);
                attackAction.UndoAction();
                Console.WriteLine("->Остановка атаки снизу");
            }); 
        }
        public async void AttackDirect()
        {
            attackAction.DoAction();
            Console.WriteLine("->Колящая атака прямо");
            await Task.Run(() => {
                Thread.Sleep(2000);
                attackAction.UndoAction();
                Console.WriteLine("->Остановка колющей атаки прямо");
            }); 
        }
        public async void AttackLeftward()
        {
            attackAction.DoAction();
            Console.WriteLine("->Атакуем слева");
            await Task.Run(() => {
                Thread.Sleep(2000);
                attackAction.UndoAction();
                Console.WriteLine("->Остановка атаки слева");
            }); 
        }
        public async void AttackOverhand()
        {
            attackAction.DoAction();
            Console.WriteLine("->Атакуем сверху");
            await Task.Run(() => {
                Thread.Sleep(2000);
                attackAction.UndoAction();
                Console.WriteLine("->Остановка атаки сверху");
            }); 
        }
        public async void AttackOverhandDownJump()
        {
            attackAction.DoAction();
            Console.WriteLine("->Атакуем в прыжке сверху вниз");
            await Task.Run(() => {
                Thread.Sleep(2000);
                attackAction.UndoAction();
                Console.WriteLine("->Остановка атаки сверху вниз");
            }); 
        }
        public async void AttackRightward()
        {
            attackAction.DoAction();
            Console.WriteLine("->Атакуем справа");
            await Task.Run(() => {
                Thread.Sleep(2000);
                attackAction.UndoAction();
                Console.WriteLine("->Остановка атаки справа");
            }); 
        }

        #endregion
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var bonereader = new BoneReaper
            {
                Name = "Костяной жнец", 
                Force = 10000
            };
            var nameMob = bonereader.Name;
            var forceMob = bonereader.Force;
            Console.WriteLine($"Имя: {nameMob}; Сила: {forceMob} ");
            Console.WriteLine("\n");

            bonereader.MoveForward();
            bonereader.AttackDirect();
            Console.WriteLine("\n");

            Console.Read();
        }
    }
}
