import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>The work from home logbook app</h1>
        <img src={require("./wfh-log-animation.gif")} className="App-logo" alt="animation of the wfh-log app" />
        <p>
          Automatically log your work from home hours for tax purposes for government bodies like the 
          Internal Revenue Service (IRS) or Australian Tax Office (ATO).
        </p>
        <span>
          <a 
            className="App-link"
            href="https://github.com/dylan-george-field/work-from-home-logger/releases/latest/download/wfh-log.exe"
            target="_blank"
            rel="noopener noreferrer"
            id="download">
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
        <a href="https://www.georgefield.com.au/contact" rel="noreferrer" target="_blank">Send feedback</a>
      </footer>
    </div>
  );
}

export default App;
