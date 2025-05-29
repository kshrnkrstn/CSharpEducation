namespace Phonebook;

/// <summary>
/// Один абонент.
/// </summary>
public class Abonent
{
    #region Свойства
    
        /// <summary>
        /// Имя абонента.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Номер телефона абонента.
        /// </summary>
        public string PhoneNumber { get; set; }
        
    #endregion

    #region Конструкторы

    /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        /// <param name="phoneNumber">Номер телефона абонента.</param>
        public Abonent(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

    #endregion
    



}