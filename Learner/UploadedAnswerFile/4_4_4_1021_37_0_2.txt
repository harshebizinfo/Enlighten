UPDATE Tbl_booknow
SET Tbl_booknow.reptno = CashierAmt_tbl.rectno 

FROM Tbl_booknow, CashierAmt_tbl 
WHERE CashierAmt_tbl.sid = Tbl_booknow.id