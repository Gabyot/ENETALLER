using System;
using ENETALLER.app.data.model;

namespace ENETALLER.app.data.mock
{
	public static class MockData
	{
        public static Dictionary<string, AFP> AFPDictionary { get; } = new Dictionary<string,AFP>()
        {
            { "CUPRUM", new AFP("CUPRUM", 0.07) },
            { "MODELO", new AFP("MODELO", 0.09) },
            { "CAPITAL", new AFP("CAPITAL", 0.12) },
            { "PROVIDA", new AFP("PROVIDA", 0.13) }
        };

        public static Dictionary<string, Health> HealthDictionary { get; } = new Dictionary<string, Health>()
        {
            { "FONASA", new Health("FONASA", 0.12)},
            { "CONSALUD", new Health("CONSALUD", 0.13)},
            { "MASVIDA", new Health("MASVIDA", 0.14)},
            { "BANMEDICA", new Health("BANMEDICA", 0.15)}
        };

        public static Employee gabriela = new Employee("Gabriela Arancibia", "usuario", "contraseña", "admin", "Dirección",
                "974761444", "19349612-1", MockData.AFPDictionary["CUPRUM"], MockData.HealthDictionary["FONASA"], 5000, 7000, 0, 0);
    }
}

