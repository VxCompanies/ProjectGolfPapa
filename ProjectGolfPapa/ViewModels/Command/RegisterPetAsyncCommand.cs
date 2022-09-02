using ProjectGolfPapa.ViewModels.Service;
using System;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels.Command
{
    public class RegisterPetAsyncCommand : AsyncCommandBase
    {
        public override async Task ExecuteAsync(object? parameter)
        {
            var registerPetViewModel = (RegisterPetViewModel)parameter!;

            registerPetViewModel.Pet.Gender = registerPetViewModel.IsMale ? "Male" : "Female";

            registerPetViewModel.Pet.Location.Coordinates = new decimal[2] {registerPetViewModel.X, registerPetViewModel.Y};

            if (!await MongoDbService.RegisterPet(registerPetViewModel.Pet))
            {
                registerPetViewModel.IsError = true;
                return;
            }

            registerPetViewModel.Pet = new()
            {
                BirthDate = DateTime.Today,
                Owner = new(),
                Location = new()
            };
        }

        public override bool CanExecute(object? parameter)
        {
            var registerPetViewModel = (RegisterPetViewModel)parameter;

            if (registerPetViewModel is null)
                return false;

            if (string.IsNullOrWhiteSpace(registerPetViewModel.Pet.Name))
                return false;

            if (string.IsNullOrWhiteSpace(registerPetViewModel.Pet.Species))
                return false;

            if (string.IsNullOrWhiteSpace(registerPetViewModel.Pet.Race))
                return false;

            if (registerPetViewModel.Pet.BirthDate > DateTime.Today)
                return false;

            if (string.IsNullOrWhiteSpace(registerPetViewModel.Pet.Owner.FirstName))
                return false;

            if (string.IsNullOrWhiteSpace(registerPetViewModel.Pet.Owner.LastName))
                return false;

            return base.CanExecute(parameter);
        }
    }
}
