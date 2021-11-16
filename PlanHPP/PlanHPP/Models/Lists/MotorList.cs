using System.Collections.Generic;

namespace PlanHPP.Models.Lists
{
    public static class MotorList
    {
        public static List<Motor> motors = new List<Motor>();
        static MotorList()
        {
            motors = new List<Motor>();
            motors.Add(new Motor()
            {
                ID = 1,
                Name = "Резервное возбуждение",
                Switch = "Секция 1, ячейка 607",
                Indicator = 1,
                X = 0.014375,
                Y = 0.034375
            });
            motors.Add(new Motor()
            {
                ID = 2,
                Name = "Насос орошения ферм",
                Switch = "Секция 2, ячейка 33",
                Indicator = 0,
                X = 0.9375,
                Y = 0.9046875
            });
            motors.Add(new Motor()
            {
                ID = 3,
                Name = "ПЭН-1",
                Switch = "Секция 1, ячейка 601",
                Indicator = 0,
                X = 0.54375,
                Y = 0.46484375
            });
            motors.Add(new Motor()
            {
                ID = 4,
                Name = "ПН-1",
                Switch = "Секция 1, ячейка 603",
                Indicator = 0,
                X = 0.858125,
                Y = 0.40625
            });
            motors.Add(new Motor()
            {
                ID = 5,
                Name = "ПОМН ТГ-1",
                Switch = "Секция 1, ячейка 4А",
                Indicator = 0,
                X = 0.858125,
                Y = 0.33515625
            });
            motors.Add(new Motor()
            {
                ID = 6,
                Name = "Ав. м/н = ТГ-1",
                Switch = "ГЩУ, панель 198",
                Indicator = 0,
                X = 0.774375,
                Y = 0.3578125
            });
            motors.Add(new Motor()
            {
                ID = 7,
                Name = "Ав. м/н ~ ТГ-1",
                Switch = "Сборка ТГ-1",
                Indicator = 0,
                X = 0.72875,
                Y = 0.3578125
            });
            motors.Add(new Motor()
            {
                ID = 8,
                Name = "КНБ-1А",
                Switch = "Секция 1, ячейка 7-Б",
                Indicator = 1,
                X = 0.310625,
                Y = 0.6625
            });
            motors.Add(new Motor()
            {
                ID = 9,
                Name = "КНБ-1Б",
                Switch = "Секция 1, ячейка 14-Б",
                Indicator = 1,
                X = 0.36375,
                Y = 0.6625
            });
            motors.Add(new Motor()
            {
                ID = 10,
                Name = "СН-1",
                Switch = "Секция 1, ячейка 608",
                Indicator = 0,
                X = 0.148125,
                Y = 0.62890625
            });
            motors.Add(new Motor()
            {
                ID = 11,
                Name = "СН-2",
                Switch = "Секция 2, ячейка 633",
                Indicator = 0,
                X = 0.148125,
                Y = 0.4640625
            });
            motors.Add(new Motor()
            {
                ID = 12,
                Name = "ЦН-1А",
                Switch = "Секция 1, ячейка 605",
                Indicator = 0,
                X = 0.028125,
                Y = 0.60703125
            });
            motors.Add(new Motor()
            {
                ID = 13,
                Name = "ЦН-1Б",
                Switch = "Секция 2, ячейка 629",
                Indicator = 0,
                X = 0.028125,
                Y = 0.44375
            });
            motors.Add(new Motor()
            {
                ID = 14,
                Name = "КНТ-1А",
                Switch = "Секция 1, ячейка 3-Б",
                Indicator = 0,
                X = 0.17375,
                Y = 0.04296875
            });
            motors.Add(new Motor()
            {
                ID = 15,
                Name = "КНТ-1Б",
                Switch = "Секция 2, ячейка 28-Б",
                Indicator = 0,
                X = 0.223125,
                Y = 0.04296875
            });
            motors.Add(new Motor()
            {
                ID = 16,
                Name = "Сливной насос-1А",
                Switch = "Секция 1, ячейка 7-А",
                Indicator = 1,
                X = 0.41,
                Y = 0.04296875
            });
            motors.Add(new Motor()
            {
                ID = 17,
                Name = "Сливной насос-1Б",
                Switch = "Секция 1, ячейка 14-А",
                Indicator = 1,
                X = 0.49875,
                Y = 0.04296875
            });

        }

    }
}

