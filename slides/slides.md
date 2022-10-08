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


<v-click>

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

</v-click>

::right::

<v-click>

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

</v-click>

---
layout: two-cols
---

<v-click>

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

</v-click>

::right::

<v-click>

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

</v-click>

---
layout: two-cols
---

<v-click>

### TypeScript
- Microsoft
- 2012
- C-Style Syntax
- Kompiliert zu JavaScript

</v-click>

::right::

<v-click>

### C#
- Microsoft
- 2000
- C-Style Syntax
- Kompiliert zu Common Intermediate Language

</v-click>

---

## Agenda
- Sprachfeatures
- Projektsetup & Ökosystem
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

<v-click>


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

</v-click>

::right::

<v-click>

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

</v-click>


---
layout: heading-two-cols
---

## Generics

::left::

<v-click>

```ts


function map<A, B>(value: A, mappingFn: (val: A) => B): B {
  return mappingFn(value);
}


const r = map<string, number>('a', (s: string) => s.length);
const r_ = map('a', s => s.length);
```

</v-click>


::right::

<v-click>

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

</v-click>

---
layout: heading-two-cols
---

## Records

::left::

<v-click>

```ts
// Record is an object type with 
// key type K and value type V: Record<K, V>
const numberedTransactions: Record<number, Transaction> = {
  0: new Transaction(-7),
  1: new Transaction(36),
  2: new Transaction(6),
};
```

</v-click>

::right::

<v-click>

```csharp
// Record is a reference type for encapsulating data 
// with built-in functionality:
// compare by value, immutability, toString formatting 
public record Person(string FirstName, string LastName);
```

</v-click>

---
layout: heading-two-cols
---

## async/await

::left::

<v-click>

```ts
const getTodos = async () => {
  
  const url = 'https://jsonplaceholder.typicode.com/todos/1';
  const json = await fetch(url);
  const parsedTodos = await json.json();

  console.log(parsedTodos);
};
```

</v-click>


::right::

<v-click>

```csharp
public static async void GetTodos() {
    using var httpClient = new HttpClient();
    var url = "https://jsonplaceholder.typicode.com/todos/1";
    var json = await httpClient.GetStringAsync(url);
    var parsedTodos = JsonConvert.DeserializeObject<Todo>(json);

    System.Console.WriteLine(parsedTodos);
}
```

</v-click>

--- 

## Structural Typing

<v-click>

```ts
interface Monument {
  age: number,
  name: string
}

interface Dog {
  age: number,
  name: string
}
```

</v-click>

<v-click>

```ts
function getCentury(monument: Monument) {
  console.log("the monument is from the Xth century!");
}

const dog: Dog = { age: 6, name: "Michel" };
getCentury(dog); 
```

</v-click>

<v-click>

```ts
// compiler: 👍
```

</v-click>


---

## Projektsetup

### package.json

<v-click>

- Informationen zur Software
- Skripte
- Abhängigkeiten
- Konfiguration

</v-click>

---

<div class="code-very-small">

```json
{
  "name": "service",
  "version": "0.7.0",
  "description": "",
  "main": "app.ts",
  "directories": {
    "test": "test"
  },
  "scripts": {
    "postinstall": "rm -rf dist",
    "test": "cross-env NODE_ENV=test jest --runInBand --forceExit --detectOpenHandles",
    "test:watch": "npm run test -- --watch",
    "build": "rm -rf dist && tsc --sourceMap --project ./",
    "dev": "nodemon --watch src --ext ts --exec \"tsc && fastify start --address 0.0.0.0 --port 3000 --log-level debug --pretty-logs dist/app.js\"",
    "lint": "tsc && eslint --max-warnings 0 ./src"
  },
  "dependencies": {
    "better-sqlite3": "7.6.2",
    "common": "file:../common",
    "date-fns": "2.29.3",
    "fastify": "4.6.0",
  },
  "devDependencies": {
    "@types/jest": "29.0.3",
    "@types/node": "18.7.21",
    "typescript": "4.8.3"
  },
  "peerDependencies": {
    "eslint-plugin-project-rules": "file:../eslint-rules"
  }
}
```

</div>

---

## Projektsetup

### tsconfig.json
- Settings für den TypeScript-Compiler
  
<v-click>

```json
{
  "extends": "fastify-tsconfig",
  "compilerOptions": {
    "outDir": "dist",
    "emitDecoratorMetadata": true,
    "experimentalDecorators": true,

    "strict": true,
    "strictNullChecks": true,
    "noImplicitThis": true,
    "noImplicitAny": true,
    "noUnusedParameters": false,
    "noUnusedLocals": false,
    "baseUrl": ".",
    "paths": {
    }
  },
  "include": [
    "src/**/*.ts"
  ]
}
```

</v-click>

---

## Ökosystem

<v-click>

- npm (node package manager)
- Paketverwaltung und Skript-Runner
- [https://www.npmjs.com/](https://www.npmjs.com/)

</v-click>

<v-click>

- Es gibt für alles ein Paket!

</v-click>

<v-click>

- Man muss nicht für alles ein Paket nutzen...
- Verfallsdatum, "code rot"

</v-click>

---

## Agenda
- Sprachfeatures
- Projektsetup & Ökosystem
- **Server-Programmierung**
- Browser-Programmierung
- TypeScript-Einstieg

---

## Serverprogrammierung

<v-click>


- guter Einstieg in TypeScript
- keine Browser-Konzepte notwendig

</v-click>

<v-click>

- node.js Besonderheiten beachten!
  - Single-Threaded -> CPU-bound tasks vermeiden
  - Imperatives Modell -> Spaghetti-Code-Gefahr
  - Zu viel Auswahl kann auch zum Fluch werden

</v-click>

---
layout: heading-two-cols
---
## TypeScript: node.js mit fastify

::left::

<v-click>

### package.json

```json
{
  "name": "fastify-example",
  "version": "1.0.0",
  "main": "index.js",
  "scripts": {
    "build": "tsc -p tsconfig.json",
    "start": "node index.js"
  },
  "dependencies": {
    "fastify": "^4.7.0"
  },
  "devDependencies": {
    "@types/node": "^18.8.2",
    "typescript": "^4.8.4"
  }
}
```

</v-click>


::right::

<v-click>

### index.ts

```ts
import fastify from "fastify";

const server = fastify();

let lastVal: string | undefined = undefined;

server.post("/set", async (request, reply) => {
  lastVal = request.body as string;
});

server.get("/get", async (request, reply) => {
  return lastVal;
});

server.listen({ port: 55555 }, (err, address) => {
  if (err) {
    console.error(err);
    process.exit(1);
  }
  console.log(`Server listening at ${address}`);
});

```

</v-click>


---
layout: heading-two-cols
---

## C#: Minimal API

::left::

<v-click>

### .csproj

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

</Project>
```

</v-click>

::right::

### Program.cs

<v-click>

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string? lastVal = null;

app.MapGet("/get", () => lastVal);
app.MapPost("/set", (Value val) => lastVal = val.Val);

app.Run("http://localhost:44444");

record Value(string Val);
```

</v-click>

---

## node.js Server-Frameworks
- [fastify](https://www.fastify.io/)
- [Koa](https://koajs.com/)
- [express](https://expressjs.com/)
- [NextJS](https://nextjs.org/)
- [NuxtJS](https://nextjs.org/)
- [SvelteKit](https://kit.svelte.dev/)
- ...

---

## Unit-Testing
- [jest](https://jestjs.io/)
- [vitest](https://vitest.dev/)
- [jasmine](https://jasmine.github.io/)+[karma](https://karma-runner.github.io/6.4/index.html) (BDD)
- [cucumber](https://cucumber.io/) (BDD)
- ...

<v-click>

```ts
// vitest example
import {describe, it, expect} from 'vitest';
import { iToString } from './app';

describe('FizzBuzz', () => {
  describe('iToString', () => {
    it('outputs Fizz for 3', () => {
        expect(iToString(3)).toBe('Fizz');
    });

    it('outputs Buzz for 5', () => {
        expect(iToString(5)).toBe('Buzz');
    });
  })
})
```

</v-click>

---

## Browser-Programmierung

<v-click>

- C# mit Blazor WebAssembly

</v-click>

<v-click>

- TypeScript als Obermenge von JavaScript
- TypeScript ist nicht die Schwierigkeit, sondern die ganzen Browser-APIs

</v-click>

---

## "vanilla"-TypeScript-Beispiel: Projektsetup

<img src="/img/create-vanilla-ts-project.gif" alt="project creation with vite gif" style="width: 90%;" />

---
layout: heading-two-cols
---

## "vanilla"-TypeScript-Beispiel: Code

::left::

<v-click>

<div class="code-small">

```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <link rel="icon" type="image/svg+xml" href="/vite.svg" />
    <meta name="viewport" 
          content="width=device-width, initial-scale=1.0" />
    <title>Vite + TS Example</title>
  </head>
  <body>
    <label for="todo">Todo:</label>
    <input 
          type="text" 
          name="todo" 
          id="todo" 
          required 
          maxlength="255" />
    <button type="button" id="save">Save</button>

    <ul id="todos-list">
    </ul>

    <script type="module" src="/src/main.ts"></script>
  </body>
</html>
```

</div>

</v-click>

::right::

<div class="code-small">

<v-click>

```ts
import './style.css'

// wait until everything is loaded
window.onload = () => {
  // select elements via id
 const saveButton = document.querySelector('#save');
 const input: HTMLInputElement | null = document.querySelector('#todo');
 const todosList = document.querySelector('#todos-list');

  if (saveButton && input && todosList) {
    saveButton.addEventListener('click', () => {
      // get value and append new list item to list
      const todoText = input.value;
      if (todoText) {
          const li = document.createElement('li');
          li.innerHTML = todoText;
          todosList.appendChild(li);

          // reset input value
          input.value = "";
      }
    });
  }
}
```

</v-click>

</div>

---

## Web-Frameworks für Single Page Applications
- [Angular](https://angular.io/)
- [React](https://reactjs.org/)
- [Vue](https://vuejs.org/)
- [Svelte](https://svelte.dev/)
- ...

<v-click>

- [Pokémon or JavaScript framework?](https://oylenshpeegul.github.io/pokemon-or-javascript/)

</v-click>


---
layout: heading-two-cols
---

## Angular Beispiel

::left::

<v-click>


```html
<div>
  <label for="todo">Todo:</label>
  <input  [formControl]="todo" 
          type="text" 
          name="todo" 
          id="todo" 
          required 
          maxlength="255" />
  <button type="button" (click)="save()">Save</button>

  <ul id="todos-list">
    <li *ngFor="let todo of todos">{{todo}}</li>
  </ul>
</div>
```

</v-click>


::right::

<v-click>


```ts
import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public readonly todos: string[] = [];
  public readonly todo = new FormControl('');

  public save(): void {
    if (this.todo.value) {
      this.todos.push(this.todo.value);
      this.todo.setValue('');
    }
  }
}
```

</v-click>

---

## Weitere Einsatzmöglichkeiten

<v-click>

Alles, was mit JavaScript geht!

</v-click>

---

## Agenda
- Sprachfeatures
- Projektsetup & Ökosystem
- Server-Programmierung
- Browser-Programmierung
- **TypeScript-Einstieg**

---

## Wie würde ich heute einsteigen?

<v-click>

- ["JavaScript Basics for Beginners" auf Udemy](https://www.udemy.com/course/javascript-basics-for-beginners/)

</v-click>
<v-click>

- ["Understanding TypeScript - 2022 Edition" auf Udemy](https://www.udemy.com/course/understanding-typescript/)

</v-click>
<v-click>

- [TypeScript Track auf exercism](https://exercism.org/tracks/typescript/)

</v-click>
<v-click>

- kleine Server-Software schreiben, zum Beispiel mit [fastify](https://www.fastify.io/docs/latest/Reference/TypeScript/#typescript)

</v-click>
<v-click>

- [Einstieg in die Web-Entwicklung mit dem MDN](https://developer.mozilla.org/en-US/docs/Learn/Getting_started_with_the_web)

</v-click>
<v-click>

- Mit [vite](https://vitejs.dev/) kleine "vanilla-ts" Web-Projekte erzeugen und kleine Sachen bauen

</v-click>
<v-click>

- Für CSS: [Learn CSS in der MDN](https://developer.mozilla.org/en-US/docs/Learn/CSS), [Flexbox Froggy](http://flexboxfroggy.com/), [Grid Garden](https://cssgridgarden.com/), versuchen ein paar Layouts nachzubauen, z.B. von [Top 10 Projects For Beginners To Practice HTML and CSS Skills](https://www.geeksforgeeks.org/top-10-projects-for-beginners-to-practice-html-and-css-skills/)

</v-click>
<v-click>

- (["Angular - The Complete Guide (2022 Edition)" auf Udemy](https://www.udemy.com/course/the-complete-guide-to-angular-2/))

</v-click>

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
      <a href="https://groma84.github.io/learn-ts-coming-from-csharp/">
      https://groma84.github.io/learn-ts-coming-from-csharp/
      </a>
      </td>
    </tr>
    <tr><td></td>
    <td><img style="object-fit: contain; width: 120px;" src="/img/gh-pages-qrcode.svg" alt="QR-Code mit dem Link zum Vortrag auf Github Pages" /></td></tr>
  </tbody>
  </table>

 
</div>
