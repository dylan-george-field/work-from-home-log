import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>work from home log</h1>
        <p className="no-margin-top">Automatically record your WiFi network hourly</p>
        <img 
           alt="A scrolling animation of the work from home log using microsoft notepad."
           src={require("./wfh-log-demo.gif")}
           className="App-logo"
        />
        <div className="flex-container">
            <a 
              className="App-link"
              href="https://github.com/dylan-george-field/work-from-home-logger/releases/latest/download/wfh-log.exe"
              target="_blank"
              rel="noopener noreferrer"
              id="download">
                Download (Windows 🪟)
            </a>
            <span className="divider">|</span>
            <a
            className="App-link"
            href="https://github.com/dylan-george-field/work-from-home-log"
            target="_blank"
            rel="noopener noreferrer">
              Source Code (GitHub)
            </a>
        </div>
        <h2>Installation instructions ✅</h2>
          <ol className="no-margin-top no-list">
            <li>Download the app</li>
            <li>Open 'run' app ('Windows + R')</li>
            <li>Type 'shell:startup' and hit OK</li>
            <li>Paste the 'wfh-log.exe' into this folder</li>
          </ol>
      </header>
      <footer>
        <a href="https://www.georgefield.com.au/contact" rel="noreferrer" target="_blank">Send feedback</a>
      </footer>
    </div>
  );
}

export default App;
