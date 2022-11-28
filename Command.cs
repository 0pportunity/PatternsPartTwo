namespace CommandPractic
{
    /// <summary>
    /// Базовый класс команды
    /// </summary>
    abstract class Command
    {
        /// <summary>
        /// Выполнить
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Отменить
        /// </summary>
        public abstract void Cancel();
    }
}