SELECT LEFT(FirstName, 1)
           AS [First Letter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)


