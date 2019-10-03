SELECT SUM([Result].Diff)
           AS [SumDifference]
FROM (
         SELECT DepositAmount - (
             SELECT DepositAmount
             FROM WizzardDeposits
                      AS w
             WHERE w.Id = wd.Id + 1
         )
                    AS Diff
         FROM WizzardDeposits
                  AS wd
     )
         AS [Result]