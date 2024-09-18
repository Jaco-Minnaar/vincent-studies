import { useState } from "react";

export function Home() {
  const [displayValue, setDisplayValue] = useState("0");
  const [start, setStart] = useState(true);
  const [lastOp, setLastOp] = useState();
  const [lhs, setLhs] = useState();

  const numPressed = (num) => {
    if (start) {
      setStart(false);
      setDisplayValue(num);
    } else {
      setDisplayValue((prev) => prev + num);
    }
  };

  const opPressed = async (op) => {
    const num = parseInt(displayValue);

    if (!lhs) {
      setLhs(num);
    } else if (lastOp) {
      const result = await performOperation(lhs, lastOp, num);
      setLhs(undefined);
      setDisplayValue(result);
    }
    setStart(true);
    setLastOp(op);
  };

  const eqPressed = async () => {
    const num = parseInt(displayValue);

    if (!lhs) {
      setLhs(num);
    } else if (lastOp) {
      const result = await performOperation(lhs, lastOp, num);
      setLhs(undefined);
      setDisplayValue(result);
    }
    setStart(true);
  };

  const performOperation = async (lhs, op, rhs) => {
    const req = {
      Lhs: lhs,
      Operator: op,
      Rhs: rhs,
    };

    const res = await fetch("calculator", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(req),
    });

    if (!res.ok) {
      throw new Error("Something went wrong");
    }

    const msg = await res.json();

    return msg.result;
  };

  return (
    <div class="main-box">
      <div className="display-box">
        <div>{displayValue}</div>
      </div>
      <div className="home-box">
        <div>
          <div>
            <button onClick={() => numPressed("7")}>7</button>
            <button onClick={() => numPressed("8")}>8</button>
            <button onClick={() => numPressed("9")}>9</button>
          </div>
          <div>
            <button onClick={() => numPressed("4")}>4</button>
            <button onClick={() => numPressed("5")}>5</button>
            <button onClick={() => numPressed("6")}>6</button>
          </div>
          <div>
            <button onClick={() => numPressed("1")}>1</button>
            <button onClick={() => numPressed("2")}>2</button>
            <button onClick={() => numPressed("3")}>3</button>
          </div>
          <div>
            <button onClick={() => numPressed("0")}>0</button>
            <span></span>
          </div>
        </div>
        <div>
          <div className="ops">
            <button onClick={() => opPressed("+")}>+</button>
            <button onClick={() => opPressed("+")}>-</button>
            <button onClick={() => opPressed("*")}>X</button>
            <button onClick={() => opPressed("/")}>/</button>
            <button onClick={() => eqPressed()}>=</button>
          </div>
        </div>
        <div>
          <button
            onClick={() => {
              setDisplayValue("0");
              setStart(true);
              setLastOp(undefined);
              setLhs(undefined);
            }}
          >
            Clear
          </button>
        </div>
      </div>
    </div>
  );
}
