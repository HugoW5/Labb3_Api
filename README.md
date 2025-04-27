## Endpoints Dokumentering

| Metod | Endpoint | Beskrivning |
|:-----|:---------|:------------|
| GET | `/api/Person` | Hämta alla personer |
| POST | `/api/Person` | Skapa en ny person |
| GET | `/api/Person/{personId}` | Hämta en person via ID |
| GET | `/api/Person/{personId}/Interests` | Hämta alla intressen kopplade till en person |
| GET | `/api/Person/{personId}/links` | Hämta alla länkar kopplade till en person |
| PUT | `/api/Person/{personId}/interests` | Lägg till ett nytt intresse till en person |
| GET | `/api/Interest` | Hämta alla intressen |
| POST | `/api/Interest` | Skapa ett nytt intresse |
| PUT | `/api/Link` | Lägg till en ny länk för intresse och person|


