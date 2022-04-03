using System.Linq;
using System.Text.Json;

namespace Server.Serialize
{
    public static class Serialaze
    {
        private static Input input = new Input();
        private static Output output = new Output();


        public static void AddInput(string strJson)
        {
            Input? input = JsonSerializer.Deserialize<Input>(strJson);
            TaskComplerion();
        }
        private static void TaskComplerion()
        {
            for (int i = 0; i < input.Sums.Length; i++)
            {
                output.SumResult += input.Sums[i];
                if (!String.IsNullOrEmpty(input.Muls[i].ToString()))
                {
                    output.MulResult *= input.Muls[i];
                }
            }
            output.SumResult *= input.K;

            decimal[] newarray = new decimal[input.Muls.Length];
            for (int i = 0; i < input.Muls.Length; i++)
            {
                newarray[i] = Convert.ToDecimal(input.Muls[i]);
            }
            output.SortedInputs =  input.Sums.Concat(newarray).ToArray();
            Array.Sort(output.SortedInputs);       
        }
        public static string JsonResponse()
        {
            return JsonSerializer.Serialize(output);
        }
    }
}