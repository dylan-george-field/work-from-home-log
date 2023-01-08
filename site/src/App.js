import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>The work from home logbook app</h1>
        <img src={require("./example.png")} className="App-logo" alt="screenshot of wfh-log" />
        <p>
          Automatically log your work from home hours for tax purposes for government bodies like the 
          Internal Revenue Service (IRS) or Australian Tax Office (ATO).
        </p>
        <span>
          <a 
            className="App-link"
            href="https://github.com/dylan-george-field/work-from-home-logger/releases/latest/download/wfh-log.exe"
            target="_blank"
            rel="noopener noreferrer">
              Download 
          </a>
           | 
          <a
           className="App-link"
           href="https://github.com/dylan-george-field/work-from-home-logger/wiki"
           target="_blank"
           rel="noopener noreferrer">
            Wiki
          </a>
        </span>
        <p>Place the wfh-log.exe in your startup folder.</p>
      </header>
      <footer>
        <a href="https://www.georgefield.com.au">www.georgefield.com.au</a>
      </footer>
    </div>
  );
}

export default App;
