namespace FastService.API.Shared.Extensions
{
    public static class CustomRandom
    {
        private static readonly System.Random random = new System.Random();

        private static readonly string[] especialidades = {
            "Limpiador(a)",
            "Técnico(a) de Electrodomésticos",
            "Jardinero(a)",
            "Plomero(a)",
            "Pintor(a)",
            "Cerrajero(a)",
            "Fumigador(a)",
            "Técnico(a) de Techos",
            "Mudancero(a)",
            "Cuidador(a) de Niños",
            "Cuidador(a) de Mascotas",
            "Fontanero(a)",
            "Electricista",
            "Sastre/Sastresa",
            "Mecánico(a) de Bicicletas",
            "Fontanero(a)",
            "Instalador(a) de Persianas",
            "Zapatero(a)",
            "Carpintero(a)",
            "Instalador(a) de Estantes",
            // Agrega más profesiones aquí
        };

        // Retorna un valor aleatorio entre 500 y 1000
        public static int GetRandomValueBetween500And1000()
        {
            return random.Next(500, 1001);
        }

        // Retorna un número aleatorio entre 1 y 5
        public static int GetRandomNumberBetween1And5()
        {
            return random.Next(1, 6);
        }

        // Retorna una especialidad aleatoria del arreglo
        public static string GetRandomEspecialidad()
        {
            int index = random.Next(especialidades.Length);
            return especialidades[index];
        }

        
    }
}
