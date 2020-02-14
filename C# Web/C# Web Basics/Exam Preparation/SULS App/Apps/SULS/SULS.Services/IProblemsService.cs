using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void CreateProblem(string name,int points);

        string GetProblemId(string name,int points);
    }
}
