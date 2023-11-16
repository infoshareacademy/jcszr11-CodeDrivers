using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDrivers.Repository;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        ReservationRepository reservationRepository = new ReservationRepository();

        Car car = new Car(CarBrand.BMW, "A1");
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
                Console.WriteLine("1: Wyświetl wszystkie dostępne auta");
                Console.WriteLine("2: Dodaj auto do listy");
                Console.WriteLine("3: Usuń auto z listy");
                Console.WriteLine("4: Edytuj pozycję samochodu");
                Console.WriteLine("5: Zmień range (na usera)");
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
                        Console.WriteLine("Wyświetl wszystkie dostępne auta");
                        Console.WriteLine();
                        carListRepository.DisplayItems(carListRepository.GetAllAvailable());
                        AdminPanel();
                        break;
                    case 2:
                        Console.WriteLine("Dodaj auto do listy");
                        Console.WriteLine();
                        AddCar();
                        AdminPanel();
                        break;
                    case 3:
                        Console.WriteLine("Usuń auto z listy");
                        Console.WriteLine();
                        RemoveCar();
                        AdminPanel();
                        break;
                    case 4:
                        Console.WriteLine("Edytuj wartości samochodu z listy");
                        Console.WriteLine();
                        EditPosition();
                        AdminPanel();
                        break;
                    case 5:
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
                Console.WriteLine("3: Odwolaj rezerwacji");
                Console.WriteLine("4: Zarezerwuj pojazd");
                Console.WriteLine("5: Zmień range (na admina)");
                Console.WriteLine("######################");
                Console.WriteLine();
                int userIntPanel = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (userIntPanel > 5 || userIntPanel < 0)
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
                        carListRepository.DisplayItems(carListRepository.GetAllAvailable());
                        Console.WriteLine("");
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
                        AddReservation();
                        UserPanel();
                        break;
                    case 5:
                        Console.WriteLine("Zmien range (testowe)");
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
                CarEditInformation(0, 0);
            }
            catch
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
                Console.Clear();
                carListRepository.DisplayItems(carListRepository.GetAll());
                Console.WriteLine("* Wprowadź Id samochodu jaki chcesz usunąć z listy:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                carListRepository.RemoveCar(id);
                Console.Clear();
                Console.WriteLine($"Samochód został usunięty z listy");
                carListRepository.DisplayItems(carListRepository.GetAll());
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
            carListRepository.DisplayItems(carListRepository.GetAll());
            Console.WriteLine("* Wpisz ID aby zmienić wartości danego samochodu:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < carListRepository.GetAll().Count; i++)
            {
                if (id == carListRepository.GetAll()[i].Id)
                {
                    canEdit = true;
                    break;
                }
            }
            if (canEdit)
            {
                CarEditInformation(1, id);
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
            CarBrand carBrand;
            string carBrandString;
            string carBrandLetterCapitalized;
            do
            {
                Console.WriteLine("* Wprowadz marke:");
                carBrandString = Console.ReadLine();
                Console.WriteLine();
                carBrandString.ToLower(); //Zamienia wszystkie litery na małe
                CarBrand carBrand1;
                if (string.Equals(carBrandString, "BMW", StringComparison.OrdinalIgnoreCase) || string.Equals(carBrandString, "VW", StringComparison.OrdinalIgnoreCase))
                {
                    carBrandLetterCapitalized = carBrandString.ToUpper();
                    carBrandString = carBrandLetterCapitalized;
                }
                else if (Enum.TryParse(carBrandString, true, out carBrand1))
                {
                    carBrandLetterCapitalized = char.ToUpper(carBrandString[0]) + carBrandString.Substring(1); //Zamienia 1 litere na wielka
                    carBrandString = carBrandLetterCapitalized;
                }
                else
                {
                    Console.WriteLine("* Marka nie poprawna, Wprowadź ponownie");
                    Console.WriteLine("");
                }
            } while (!Enum.TryParse(carBrandString, true, out carBrand));
            Console.WriteLine();
            car.Brand = carBrand;
            Console.WriteLine("* Wprowadz model:");
            foreach (var modelList in car.Models)
            {
                Console.WriteLine(modelList);
            }
            Console.WriteLine();
            string carModel;

            do
            {
                carModel = Console.ReadLine().ToLower();
                string carModelLetterCapitalized;

                if (string.Equals(carModel, "RAV4", StringComparison.OrdinalIgnoreCase))
                {
                    if (carBrand == CarBrand.Toyota)
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
                else if (string.Equals(carModel, "up!", StringComparison.OrdinalIgnoreCase))
                {
                    if (carBrand == CarBrand.VW)
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

                if (!car.Models.Contains(carModel))
                {
                    Console.WriteLine("* Model niepoprawny. Wprowadź ponownie.");
                }

            } while (!car.Models.Contains(carModel));
            Console.WriteLine();
            Console.WriteLine("* Wprowadż rodzaj:");
            foreach (var segment in Enum.GetValues(typeof(CarSegment)))
            {
                Console.WriteLine(segment);
            }
            string carSegmentString;

            do
            {
                carSegmentString = Console.ReadLine().ToLower();
                Console.WriteLine();

                string carSegmentLetterCapitalized;
                CarSegment carSegment1;

                if (string.Equals(carSegmentString, "SUV", StringComparison.OrdinalIgnoreCase))
                {
                    carSegmentLetterCapitalized = carSegmentString.ToUpper();
                    carSegmentString = carSegmentLetterCapitalized;
                }
                else if (Enum.TryParse(carSegmentString, true, out carSegment1))
                {
                    carSegmentLetterCapitalized = char.ToUpper(carSegmentString[0]) + carSegmentString.Substring(1);
                    carSegmentString = carSegmentLetterCapitalized;
                }
                else
                {
                    Console.WriteLine("* Niepoprawny rodzaj. Wprowadź ponownie.");
                }

            } while (!Enum.GetNames(typeof(CarSegment)).Any(x => string.Equals(x, carSegmentString, StringComparison.OrdinalIgnoreCase)));

            CarSegment carSegment = (CarSegment)Enum.Parse(typeof(CarSegment), carSegmentString);
            Console.WriteLine();
            car.Segment = carSegment;
            Console.WriteLine("* Wprowadz rodzaj napędu:");
            foreach (var gearType in Enum.GetValues(typeof(GearType)))
            {
                Console.WriteLine(gearType);
            }
            string gearTypeString;
            do
            {
                gearTypeString = Console.ReadLine().ToLower();
                Console.WriteLine();

                string gearTypeLetterCapitalized;
                GearType gearType1;

                if (Enum.TryParse(gearTypeString, true, out gearType1))
                {
                    gearTypeLetterCapitalized = char.ToUpper(gearTypeString[0]) + gearTypeString.Substring(1);
                    gearTypeString = gearTypeLetterCapitalized;
                }
                else
                {
                    Console.WriteLine("* Niepoprawny napęd. Wprowadź ponownie.");
                }

            } while (!Enum.GetNames(typeof(GearType)).Any(x => string.Equals(x, gearTypeString, StringComparison.OrdinalIgnoreCase)));

            GearType gearTransmission = (GearType)Enum.Parse(typeof(GearType), gearTypeString);
            car.GearTransmission = gearTransmission;

            Console.WriteLine();
            decimal pricePerDay;
            do
            {
                Console.WriteLine("* Podaj cenę wypożyczenia za dzień:");

                // Wczytaj dane z konsoli
                string input = Console.ReadLine();

                // Próba przekształcenia wczytanej wartości do decimal
                if (decimal.TryParse(input, out pricePerDay))
                {
                    Console.WriteLine("Wczytano cenę wypożyczenia za dzień: " + pricePerDay);
                }
                else
                {
                    Console.WriteLine("Nie udało się przekształcić wprowadzonej wartości na liczbę dziesiętną. Spróbuj ponownie.");
                }

            } while (!IsValidPricePerDay(pricePerDay)); // Wykonuj pętlę, dopóki cena za dzień nie jest poprawna

            if (i == 0) //Add
            {
                carListRepository.AddCar(carBrand, carModel, carSegment, gearTransmission, pricePerDay);
                Console.WriteLine("Dodano samochód do listy");
            }
            else if (i == 1) //Edit
            {
                carListRepository.GetAll()[id].Brand = carBrand;
                carListRepository.GetAll()[id].Model = carModel;
                carListRepository.GetAll()[id].Segment = carSegment;
                carListRepository.GetAll()[id].GearTransmission = gearTransmission;
                carListRepository.GetAll()[id].PricePerDay = pricePerDay;
            }

        }
        static bool IsValidPricePerDay(decimal price)
        {
            // Tutaj możesz dodać dodatkowe warunki walidacyjne, jeśli są potrzebne
            return price > 0; // Przykładowy warunek - cena musi być większa niż 0
        }
        #endregion

        #region AddReservation
        void AddReservation()
        {
            DateTime? reservationStartDate = null;
            DateTime? reservationEndDate = null;
            DateTime timeNow = DateTime.Now;
            UserHandler newUser = new UserHandler();

            /*Car c1 = carListRepository.GetAll().FirstOrDefault(item => item.Id == 1);
			User u1 = null;
			string format = "dd/MM/yyyy HH:mm";
			CultureInfo provider = CultureInfo.InvariantCulture;

			DateTime beginning = DateTime.ParseExact("12/03/2024 13:00", format, provider);
			DateTime end = DateTime.ParseExact("12/04/2024 13:00", format, provider);

			Reservation r1 = new Reservation(c1, u1, beginning, end, 200);

			reservationRepository.Reservations.Add(r1);*/


            //do
            //{
            //    reservationStartDate = DataHandler.GetDate("Podaj date i godzine poczatku rezerwacji");
            //    reservationEndDate = DataHandler.GetDate("Podaj date konca rezerwacji");

            //    if (reservationStartDate >= reservationEndDate)
            //    {
            //        Console.WriteLine("Data zakończenia rezerwacji musi być większa niż data początku rezerwacji!!");
            //        reservationEndDate = DataHandler.GetDate("Podaj date konca rezerwacji");
            //    }
            //} while (reservationEndDate <= reservationStartDate);

            //List<int> bookedCarIds = reservationRepository.GetCarsReservedInGivenPeriod(reservationStartDate, reservationEndDate);

            //Console.WriteLine("W wybranym terminie sa dostepne nastepujace samochody");

            //carListRepository.DisplayItems(carListRepository.GetAllExceptCarsWithProvidedIds(bookedCarIds));
            //carListRepository.DisplayItems(carListRepository.GetAll().Where(car => !bookedCarIds.Contains(car.Id)).ToList());
            //GetAll().Where(car => !bookedCarIds.Contains(car.Id));

            //Console.WriteLine("Ktory samochod chcesz wybrac? Podaj id");

            //int chosenCarId = DataHandler.GetId();

            ////dalsza czesc tworzenia rezerwacji

            //Console.WriteLine();
            Console.Clear();
            carListRepository.DisplayItems(carListRepository.GetAll());
            Console.WriteLine();
            while (true)
            {
                reservationStartDate = DataHandler.GetDate("Podaj datę i godzinę początku rezerwacji");
                if (reservationStartDate.HasValue && reservationStartDate < timeNow)
                {
                    Console.WriteLine("Sorry.....Nie możesz cofnąć się w czasie!");
                    continue;
                }
                while (true)
                {
                    reservationEndDate = DataHandler.GetDate("Podaj date konca rezerwacji");
                    if (reservationEndDate.HasValue && reservationStartDate >= reservationEndDate)
                    {
                        Console.WriteLine("Data zakończenia rezerwacji musi być większa niż data początku rezerwacji!!");
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine($"Wszystkie dostępne samochody w termminie {reservationStartDate}-{reservationEndDate}: ");
                    Console.WriteLine();
                    carListRepository.DisplayAvailableItems(carListRepository.GetAllAvailable());
                    while (true)
                    {
                        Console.WriteLine();
                        int chosenCarId = DataHandler.GetId();
                        if (chosenCarId > carListRepository.GetAll().Count && chosenCarId < carListRepository.GetAll().Count)
                        {
                            Console.WriteLine("Niepoprawne id. Wprowadź ponownie:");
                            continue;
                        }
                        while (true)
                        {
                            newUser.AddUser();
                            Console.WriteLine("Rezerwacja zakończona ");
                            return;
                        }

                    }

                    //carListRepository.DisplayItems(carListRepository.GetAllExceptCarsWithProvidedIds(bookedCarIds));
                    //carListRepository.DisplayItems(carListRepository.GetAll().Where(car => !bookedCarIds.Contains(car.Id)).ToList());
                }
            }

        }
    }
}
#endregion
