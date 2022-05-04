﻿using WebAPI.Models;

namespace WebAPI.Managers
{
    public interface IManager<T, I>
    {
        T GetItemById(I id);

        List<T> GetAllItems();
    }
}
