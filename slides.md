---
# try also 'default' to start simple
theme: ./mathema-2021

# infos for the footer (on slides with the default-with-footer layout)
occasion: "BASTA! Mainz 2022"
occasionLogoUrl: "img/BASTA19_Website_Logo_Menu.png"
company: "MATHEMA GmbH"
presenter: "Martin Grotz"
contact: "martin.grotz@mathema.de"

# apply any windi css classes to the current slide
class: "text-center"

highlighter: shiki

defaults:
  layout: "default-with-footer"

info: |
  ## Ist doch fast das Gleiche! – TypeScript für C#-Entwickler
 
layout: cover 
---


# TypeScript für C#-Entwickler

### Martin Grotz


---
layout: two-cols
---



```ts
export class FizzBuzzer {
  constructor(private readonly upTo: number) {}

  
  private numToString(num: number): string {
    if (num % 15 === 0) {
      return 'FizzBuzz';
    } else if (num % 5 === 0) {
      return 'Buzz';
    } else if (num % 3 === 0) {
      return 'Fizz';
    } else {
      return num.toString();
    }
  }

  public fizzBuzz(): void {
    for (let i = 1; i <= this.upTo; ++i) {
      console.log(this.numToString(i));
    }
  }
}

const fb = new FizzBuzzer(100);
fb.fizzBuzz();
```

::right::

```csharp
public class FizzBuzzer {
    private readonly int upTo;
    public FizzBuzzer(int upTo) => this.upTo = upTo;
    
    private string NumToString(int num) {
        if (num % 15 == 0) {
          return "FizzBuzz"; 
        } else if (num % 5 == 0) {
          return "Buzz"; 
        } else if (num % 3 == 0) {
          return "Fizz"; 
        } else { 
          return num.ToString(); 
        }
    }

    public void FizzBuzz() {
        for (var i = 1; i <= this.upTo; ++i) {
            System.Console.WriteLine(this.NumToString(i));
        }
    }
}

var fb = new FizzBuzzer(100);
fb.FizzBuzz();
```

---
layout: two-cols
---


<div class="code-small">
```ts
export interface ITransaction {
  readonly value: number;
  toPrintable(): string;
}

export class Transaction implements ITransaction {
  
  
  constructor(public readonly value: number) {}
  public toPrintable(): string {
    return `Value: ${this.value}`;
  }
}


export const toPrintableOnlyPositive = 
  (transactions: ITransaction[]): string => {
    return transactions
      .filter(t => t.value > 0)
      .map(t => t.toPrintable())
      .join("\r\n");
  }


const ts: ITransaction[] = [
  new Transaction(-7),
  new Transaction(36),
  new Transaction(6),
];
console.log(toPrintableOnlyPositive(ts));
```

</div>

::right::

<div class="code-small">

```csharp
public interface ITransaction {
    int Value  { get; }
    string ToPrintable();
}

public class Transaction : ITransaction {
    readonly private int _Value;
    public int Value => _Value;
    public Transaction(int value) => this._Value = value;
    public string ToPrintable() {
        return $"Value: {Value}";
    }
}

public class Workflow {
    public static Func<IEnumerable<ITransaction>, string> ToPrintableOnlyPositive = 
    transactions => {
        return String.Join("\r\n", transactions
            .Where(t => t.Value > 0)
            .Select(t => t.ToPrintable())
            );
    };
}

var ts = new List<ITransaction>() {
    new Transaction(-7),
    new Transaction(36),
    new Transaction(6),
};
System.Console.WriteLine(Workflow.ToPrintableOnlyPositive(ts));
```

</div>

---
layout: two-cols
---

### TypeScript
- Microsoft
- 2012
- C-Style Syntax
- Kompiliert zu JavaScript

::right::

### C#
- Microsoft
- 2000
- C-Style Syntax
- Kompiliert zu Common Intermediate Language

---

## Agenda
- Sprachfeatures
- Projektsetup
- Server-Programmierung
- Browser-Programmierung
- TypeScript-Einstieg

---

## Sprachfeatures
- Funktionen, Klassen, Interfaces - siehe vorherige Folien
- Array-Funktionen statt IEnumerable/LINQ - siehe vorherige Folien

---
layout: heading-two-cols
---

## Enums

::left:: 

```ts
// simplest case
enum Direction {
  Up,
  Down,
}

// explicit values
enum UserResponse {
  No = 0,
  Yes = 1,
}

// string enum
enum Direction {
  Up = "UP",
  Down = "DOWN",
}

// with computed value
enum FileAccess {
  None,
  Read = 1 << 1,
  Write = 1 << 2,
  ReadWrite = Read | Write,
  
  // computed member
  G = "123".length,
}
```
::right::

```csharp
// simplest case
enum Direction {
    Up,
    Down,
}

// explicit values
enum UserResponse {
    No = 0,
    Yes = 1,
}
```

---
layout: heading-two-cols
---

## Generics

::left::

```ts


function map<A, B>(value: A, mappingFn: (val: A) => B): B {
  return mappingFn(value);
}


const r = map<string, number>('a', (s: string) => s.length);
const r_ = map('a', s => s.length);
```

::right::

```csharp
public class E
{
  public static B Map<A, B>(A value, Func<A, B> mappingFn) {
    return mappingFn(value);
  }
}

var r = E.Map<String, int>("a", (String s) => s.Length);
var r_ = E.Map("a", s => s.Length);
```

---
layout: heading-two-cols
---

## Records
- false friends - die beiden Dinge haben nichts miteinander zu tun


::left::

```ts
// Record is an object type with 
// key type K and value type V: Record<K, V>
const numberedTransactions: Record<number, Transaction> = {
  0: new Transaction(-7),
  1: new Transaction(36),
  2: new Transaction(6),
};
```

::right::

```csharp
// Record is a reference type for encapsulating data 
// with built-in functionality:
// compare by value, immutability, toString formatting 
public record Person(string FirstName, string LastName);

```

---
layout: heading-two-cols
---

## async/await



---
layout: heading-two-cols
---

## Projektsetup

::left::

package.json
tsconfig.json

::right::

.csproj

---

## Ökosystem

::left::
npm

::right::
nuget

---

## Serverprogrammierung
- guter Einstieg in TypeScript
- keine Browser-Konzepte notwendig
- node.js Besonderheiten beachten!

---

## TypeScript: node.js mit fastify

---

## C#: Minimal API(?)

---

## Andere TypeScript-Server-Frameworks

---

## Testing
Frameworks

---

## Browser
- C# mit Blazor
- TypeScript als Obermenge von JavaScript

---

## "vanilla"-Beispiel 

::left::

HTML

::right::

TypeScript

---

## Web-Frameworks

---

## Weitere Einsatzmöglichkeiten
Azure Functions
Electron
alles, was mit JavaScript geht

---

## Einstiegsmöglichkeiten

---

## Kontakt

<div class="flex">
  <ImageWithSource src="img/martin_auf_briefkasten.jpg" alt="Martins Gesicht auf einem Briefkasten" height="h-xs" style="min-width: 15rem;" />

  <table class="ml-4">
  <tbody>
    <tr>
      <td>E-Mail</td>
      <td><a href="mailto:martin.grotz@mathema.de">martin.grotz@mathema.de</a></td>
    </tr>
    <tr>
      <td>Twitter</td>
      <td><a href="https://twitter.com/mobilgroma">@mobilgroma</a></td>
    </tr>
    <tr>
      <td>Github</td>
      <td><a href="https://github.com/groma84/">groma84</a></td>
    </tr>
    <tr>
      <td>Slides</td>
      <td>
      <a href="https://groma84.github.io/TODO/">
      https://groma84.github.io/TODO/
      </a>
      </td>
    </tr>
    <tr><td></td>
    <td><img style="object-fit: contain; width: 120px;" src="/img/gh-pages-qrcode.svg" alt="TODO QR-Code mit dem Link zum Vortrag auf Github Pages" /></td></tr>
  </tbody>
  </table>

 
</div>

---
