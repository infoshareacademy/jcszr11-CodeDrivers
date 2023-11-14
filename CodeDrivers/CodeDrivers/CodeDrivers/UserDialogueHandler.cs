using CodeDrivers.Models.Car;
using CodeDrivers.Repository;
using System.Linq;


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
		#region AdminPanel
		void AdminPanel() //Panel admina
		{

			Console.WriteLine("");
			try
			{
                Console.WriteLine();
                Console.WriteLine("######################");
                Console.WriteLine("1: Dodaj auto do listy");
				Console.WriteLine("2: Usuń auto z listy");
				Console.WriteLine("3: Edytuj pozycję samochodu");
				Console.WriteLine("4: Zmień range (na usera)");
                Console.WriteLine("######################");
                Console.WriteLine();
				int userIntPanel = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (userIntPanel > 4 || userIntPanel < 0)
				{
					Console.Clear();
					Console.WriteLine("Liczba nie poprawna, wprowadź ponownie");
					AdminPanel();
				}

				switch (userIntPanel)
				{
					case 1:
						Console.WriteLine("Dodaj auto do listy");
                        Console.WriteLine();
                        AddCar();
						AdminPanel();
						break;
					case 2:
						Console.WriteLine("Usuń auto z listy");
                        Console.WriteLine();
                        RemoveCar();
						AdminPanel();
						break;
					case 3:
						Console.WriteLine("Edytuj wartości samochodu z listy");
                        Console.WriteLine();
                        EditPosition();
						AdminPanel();
						break;
					case 4:
						Console.WriteLine("Zmien range (na usera)");
                        Console.WriteLine();
                        Console.Clear();
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
		#endregion

		#region UserPanel()
		void UserPanel() //Panel uzytkownika
		{
			try
			{
                Console.WriteLine();
                Console.WriteLine("######################");
                Console.WriteLine("1: Wyświetl wszystkie dostępne auta");
				Console.WriteLine("2: Zmień termin rezerwacji");
				Console.WriteLine("3: Odwolaj rezerwacje");
				Console.WriteLine("4: Zmien range (na admina)");
                Console.WriteLine("######################");
                Console.WriteLine();
				int userIntPanel = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (userIntPanel > 4 || userIntPanel < 0)
				{
					Console.Clear();
					Console.WriteLine("Liczba nie poprawna, wprowadź ponownie");
					UserPanel();
					return;
				}

				switch (userIntPanel)
				{
					case 1:
						Console.WriteLine("Wyświetl wszystkie dostępne auta");
                        Console.WriteLine();
                        carListRepository.DisplayAllItems(carListRepository.GetAllAvailable());
						UserPanel();
						break;
					case 2:
						Console.WriteLine("Zmień termin rezerwacji");
                        Console.WriteLine();
                        UserPanel();
						break;
					case 3:
						Console.WriteLine("Odwołaj rezerwacje");
                        Console.WriteLine();
                        UserPanel();
						break;
					case 4:
						Console.WriteLine("Zmien range (na admina)");
                        Console.WriteLine();
                        Console.Clear();
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
		#endregion

		#region AddCar
		void AddCar()
		{
			try
			{
                CarEditInformation(0,0);
			} catch
			{
				AdminPanel();
			}
		}
		#endregion

		#region RemoveCar
		void RemoveCar()
		{
			try
			{
				carListRepository.DisplayAllItems(carListRepository.GetAll());
				Console.WriteLine("* Wprowadź Id samochodu jaki chcesz usunąć z listy:");
				int id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                carListRepository.RemoveCar(id);
				AdminPanel();
			}
			catch
			{
				AdminPanel();
			}

        }
        #endregion

        #region EditPosition
        void EditPosition()
		{
			bool canEdit = false;
			carListRepository.DisplayAllItems(carListRepository.GetAll());
            Console.WriteLine("* Wpisz ID aby zmienić wartości danego samochodu:");
			int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < carListRepository.GetAll().Count; i++)
			{
				if(id == carListRepository.GetAll()[i].Id)
				{
					canEdit = true; 
					break;
				}
			}
			if (canEdit)
			{
				CarEditInformation(1,id);
			}
        }
		#endregion

        #region CarEditInformation
		void CarEditInformation(int i, int id)
		{
            Console.WriteLine("* Wszystkie dostępne marki:");
            foreach (var BrandCar in Enum.GetValues(typeof(CarBrand)))
            {
                Console.WriteLine(BrandCar);
            }
            Console.WriteLine();
            Console.WriteLine("* Wprowadz marke:");
            string carBrandString = Console.ReadLine();
            Console.WriteLine();
            carBrandString.ToLower(); //Zamienia wszystkie litery na małe
			CarBrand carBrand1;
            string carBrandLetterCapitalized;
            if (string.Equals(carBrandString, "BMW", StringComparison.OrdinalIgnoreCase) || string.Equals(carBrandString, "VW", StringComparison.OrdinalIgnoreCase))
            {
                carBrandLetterCapitalized = carBrandString.ToUpper();
                carBrandString = carBrandLetterCapitalized;
            }
            else if(Enum.TryParse(carBrandString,true,out carBrand1))
            {
                carBrandLetterCapitalized = char.ToUpper(carBrandString[0]) + carBrandString.Substring(1); //Zamienia 1 litere na wielka
                carBrandString = carBrandLetterCapitalized;
			}
			else
			{
                Console.WriteLine("Marka nie poprawna");
                Console.WriteLine("");
                return;
            }
            CarBrand carBrand = (CarBrand)Enum.Parse(typeof(CarBrand), carBrandString);
            Console.WriteLine();
            car.Brand = carBrand;
            Console.WriteLine("* Wprowadz model:");
            foreach (var modelList in car.Models)
            {
                Console.WriteLine(modelList);
            }
            Console.WriteLine();
            string carModel = Console.ReadLine().ToLower();
            string carModelLetterCapitalized;
            if (string.Equals(carModel, "RAV4", StringComparison.OrdinalIgnoreCase)) //Wyjatek
            {
				if(carBrand == CarBrand.Toyota)
				{
                    carModelLetterCapitalized = carModel.ToUpper();
                    carModel = carModelLetterCapitalized;
				}
				else
				{
                    Console.WriteLine("Marka nie poprawna");
                    return;
				}
            }
            else if (string.Equals(carModel, "up!", StringComparison.OrdinalIgnoreCase)) //Wyjatek
            {
				if(carBrand == CarBrand.VW)
				{
                    carModelLetterCapitalized = carModel.ToLower();
                    carModel = carModelLetterCapitalized;
				}
				else
				{
                    Console.WriteLine("Marka nie poprawna");
                    return;
				}
            }
            else
            {
                carModelLetterCapitalized = char.ToUpper(carModel[0]) + carModel.Substring(1);
                carModel = carModelLetterCapitalized;
            }
            car.Model = carModel;
            Console.WriteLine();
            Console.WriteLine("* Wprowadż rodzaj:");
            foreach (var segment in Enum.GetValues(typeof(CarSegment)))
            {
                Console.WriteLine(segment);
            }
            string carSegmentString = Console.ReadLine().ToLower();
            Console.WriteLine();
            string carSegmentLetterCapitalized;
			CarSegment carSegment1;
            if (string.Equals(carSegmentString, "SUV", StringComparison.OrdinalIgnoreCase))
            {
                carSegmentLetterCapitalized = carSegmentString.ToUpper();
                carSegmentString = carSegmentLetterCapitalized;
            }
            else if(Enum.TryParse(carSegmentString,true,out carSegment1))
            {
                carSegmentLetterCapitalized = char.ToUpper(carSegmentString[0]) + carSegmentString.Substring(1);
                carSegmentString = carSegmentLetterCapitalized;
			}
			else
			{
                Console.WriteLine("Nie poprawny rodzaj");
                return;
			}
            CarSegment carSegment = (CarSegment)Enum.Parse(typeof(CarSegment), carSegmentString);
            Console.WriteLine();
            car.Segment = carSegment;
            Console.WriteLine("* Wprowadz rodzaj napędu:");
            foreach (var gearType in Enum.GetValues(typeof(GearType)))
            {
                Console.WriteLine(gearType);
            }
            string gearTypeString = Console.ReadLine().ToLower();
            string gearTypeLetterCapitalized;
            GearType gearType1;
			if(Enum.TryParse(gearTypeString,true,out gearType1))
			{
                gearTypeLetterCapitalized = char.ToUpper(gearTypeString[0]) + gearTypeString.Substring(1);
                gearTypeString = gearTypeLetterCapitalized;
			}
			else
			{
                Console.WriteLine("Nie poprawny napęd");
				return;
            }
            GearType gearTrasmission = (GearType)Enum.Parse(typeof(GearType), gearTypeString);
            car.GearTransmission = gearTrasmission;
            Console.WriteLine();
            Console.WriteLine("* Podaj cene wypozyczenia za dzień:");
			try
			{
                decimal pricePerDay = decimal.Parse(Console.ReadLine());
                if (i == 0) //Add
                {
                    carListRepository.AddCar(carBrand, carModel, carSegment, gearTrasmission, pricePerDay);
                }
                else if (i == 1) //Edit
                {
                    carListRepository.GetAll()[id].Brand = carBrand;
                    carListRepository.GetAll()[id].Model = carModel;
                    carListRepository.GetAll()[id].Segment = carSegment;
                    carListRepository.GetAll()[id].GearTransmission = gearTrasmission;
                    carListRepository.GetAll()[id].PricePerDay = pricePerDay;
                }
            }
			catch
			{
                Console.WriteLine("* Nie poprawna wartośc wprowadzonej ceny");
            }

        }
        #endregion
	}
}

