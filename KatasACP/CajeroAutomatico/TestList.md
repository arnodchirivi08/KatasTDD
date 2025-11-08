
| Valor | Tipo    | Número de unidades|
|-------|---------|-------------------|
| 500   | billete | 2                 |
| 200   | billete | 3                 |
| 100   | billete | 5                 |
| 50    | billete | 12                |
| 20    | billete | 20                |
| 10    | billete | 50                |
| 5     | billete | 100               |
| 2     | moneda  | 250               |
| 1     | moneda  | 500               |


| Valor | Tipo    |
|-------|---------|
| 500   | billete |
| 200   | billete |
| 100   | billete |
| 50    | billete |
| 20    | billete |
| 10    | billete |
| 5     | billete |
| 2     | modena  |
| 1     | moneda  |

7 tipos de billetes
2 tipos de monedas

Como usuario
Quiero retirar 1725€

Salida cantidad de billetes con su denominación que permita completar el valor total del retiro.

2 billetes de 500
3 billetes de 200
1 billete de  100
1 billete de  20
1 billete de  5


API posible para el cajero automático
Obsesión primitiva y pareja ajustada a la presentación

public interface ATM {
    public String withdraw(int quantity);
}

Devuelve una lista de DTO u Objetos de Valor
public interface ATM {
    public List<Money> withdraw(int quantity);
}

Outside-in

public interface ATM {
    public void withdraw(int quantity);
}