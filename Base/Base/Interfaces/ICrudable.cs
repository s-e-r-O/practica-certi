using System;
using System.Collections.Generic;

namespace Base
{
    public interface ICrudable<T>
    {
        /// <summary>
        /// Inserts a new row in the database.
        /// </summary>
        /// <param name="obj">The instance to insert as a row</param>
        /// <returns>Returns true if the insertion succeeds, otherwise returns false</returns>
        bool Create(T obj);

        /// <summary>
        /// Gets all rows from a database table.
        /// </summary>
        /// <returns>Returns a list of all rows</returns>
        List<T> Get();

        /// <summary>
        /// Updates the values of an existing row
        /// </summary>
        /// <param name="key">The unique identifier of the row</param>
        /// <param name="obj">The instance with the new values</param>
        /// <returns>Returns true if the update succeeds, otherwise returns false</returns>
        bool Update(String key, T obj);

        /// <summary>
        /// Deletes an existing row
        /// </summary>
        /// <param name="key">The unique identifier of the row</param>
        /// <returns>Returns true if the deletion succeeds, otherwise returns false</returns>
        bool Delete(String key);
    }
}
