using System;
using _090221Task.AbstractClasses;
using _090221Task.DataStructures;
using _090221Task.Entities;
using _090221Task.Exceptions;
using _090221Task.Interfaces;

namespace _090221Task.Login
{
    public static class Login
    {
        public static Employee login(Guid id, string pin, Employee[] employees)
        {
            if (employees.Length == 0)
                throw new NotEmployeeException("There is no workers!");

            var index = Array.FindIndex(employees, worker => worker.Id == id);

            if (index < 0)
                throw new NotEmployeeException($"There is no worker associated this id -> {id}");

            if (employees[index].Pin != pin)
                throw new InvalidLoginException("Pin is wrong!");

            // login is successfuly in here.
            
            return employees[index];
        }

        public static Client login(Guid id, string pin, Client[] clients)
        {
            if (clients.Length == 0)
                throw new NotEmployeeException("There is no client!");

            var index = Array.FindIndex(clients, worker => worker.Id == id);

            if (index < 0)
                throw new NotEmployeeException($"There is no client associated this id -> {id}");

            if (clients[index].Pin != pin)
                throw new InvalidLoginException("Pin is wrong!");

            // login is successfuly in here.

            return clients[index];
        }
    }
}
