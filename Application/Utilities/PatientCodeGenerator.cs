namespace Application.Utilities
{
    public static class PatientCodeGenerator
    {
        public static string GeneratePatientCode()
        {
            Random random = new Random();
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char letter = letters[random.Next(letters.Length)];
            string numbers = new string(Enumerable.Repeat("0123456789", 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return letter + numbers;
        }
    }
}
