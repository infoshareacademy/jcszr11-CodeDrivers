using CodeDrivers.Models.Car;
using CodeDrivers.Repository;


//Powitanie użytkownika. 
//Użytkownik programu dokonuje wyboru : admin/user
//Użytkownik opcjonalnie może zakończyć program: X
//Po przejściu admin/user proponuję dodatkowe menu z opcjami: 
//dla admina (wprowadzenie auta, usunięcie auta z listy, edycja pozycji)
//dla usera (Wyszukanie auta, zmiana terminu rezerwacji, odwołanie rezerwacji)

namespace CodeDrivers
{
	internal class Menu_tekstowe
	{
		CarRepository carListRepository = new CarRepository();
		Car car = new Car(CarBrand.BMW,"A1");
		public string Rang { get; set; }
		public Menu_tekstowe(string rang)
		{
			carListRepository.FillRepository();
			Rang = rang;

			switch (rang)
			{
				case "admin":
					AdminPanel();
					break;
				case "user":
					UserPanel();
					break;
			}
		}

		void AdminPanel() //Panel admina
		{
			Console.WriteLine("Tutaj pojawia sie panel admina");
			try
			{
				Console.WriteLine("1: Wprowadz auta");
				Console.WriteLine("2: Usun auta z listy");
				Console.WriteLine("3: Edycja pozycji");
				Console.WriteLine("4: Zmien range");
				Console.WriteLine();
				int userIntPanel = int.Parse(Console.ReadLine());
				if (userIntPanel > 4 || userIntPanel < 0)
				{
					Console.Clear();
					Console.WriteLine("Liczba nie poprawna, wprowadź ponownie");
					AdminPanel();
				}

				switch (userIntPanel)
				{
					case 1:
						Console.WriteLine("Dodaj auta");
                        Console.WriteLine("Wszystkie dostępne marki:");
						foreach(var BrandCar in Enum.GetValues(typeof(CarBrand)))
						{
                            Console.WriteLine(BrandCar);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Wprowadz marke:");

						string carBrandString = Console.ReadLine();
						CarBrand carBrand = (CarBrand)Enum.Parse(typeof(CarBrand), carBrandString);
                        Console.WriteLine();
                        Console.WriteLine("Wprowadz model");
						car.Brand = carBrand;
						foreach(var modelList in car.Models)
						{
                            Console.WriteLine(modelList);
                        }
                        Console.WriteLine();
                        string carModel = Console.ReadLine();
						car.Model = carModel;
						carListRepository.AddCar(carBrand, carModel, Models.Car.CarSegment.Crossover, Models.Car.GearType.Automatic, 500);
						AdminPanel();
						break;
					case 2:
						Console.WriteLine("Usun auta z listy");
						AdminPanel();
						break;
					case 3:
						Console.WriteLine("Edycja pozycji");
						AdminPanel();
						break;
					case 4:
						Console.WriteLine("Zmien range (testowe)");

						UserPanel();
						break;
				}
			}
			catch
			{
				Console.WriteLine("Erorr :(");
				AdminPanel();
			}
		}
		void UserPanel() //Panel uzytkownika
		{
			try
			{
				Console.WriteLine("1: wyświetl auto");
				Console.WriteLine("2: Zmień termin rezerwacji");
				Console.WriteLine("3: Odwolanie rezerwacji");
				Console.WriteLine("4: Zmien range");
				Console.WriteLine();
				int userIntPanel = int.Parse(Console.ReadLine());
				if (userIntPanel > 4 || userIntPanel < 0)
				{
					Console.Clear();
					Console.WriteLine("Liczba nie poprawna, wprowadź ponownie");
					UserPanel();
				}

				switch (userIntPanel)
				{
					case 1:
						Console.WriteLine("Wyswietl auto");
						carListRepository.DisplayAllItems(carListRepository.GetAllAvailable());
						Console.WriteLine("");
						UserPanel();
						break;
					case 2:
						Console.WriteLine("Zmiana terminu rezerwacji");
						UserPanel();
						break;
					case 3:
						Console.WriteLine("Odwolanie rezerwacji");
						UserPanel();
						break;
					case 4:
						Console.WriteLine("Zmien range (testowe)");
						AdminPanel();
						break;
				}
			}
			catch
			{
				Console.WriteLine("Erorrek :(");
				UserPanel();
			}
		}
	}
}

