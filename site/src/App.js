import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>work from home log</h1>
        <p className="Sub-heading">Automatically record your WiFi network hourly</p>
        <img 
           alt="A scrolling animation of the work from home log using microsoft notepad."
           src={require("./wfh-log-demo.gif")}
           className="App-logo"
        />
          <blockquote>
            <a 
                className="App-link"
                href="https://www.ato.gov.au/Media-centre/Media-releases/ATO-announces-changes-to-working-from-home-deductions/"
                target="_blank"
                rel="noreferrer"
            >
            "Taxpayers need to keep a record of all the hours worked from home for the entire income year – the Australian Tax Office (ATO) won’t accept estimates"
            </a>
          </blockquote>
          
          <br />
        <p>
        <span>
          <a 
            className="App-link"
            href="https://github.com/dylan-george-field/work-from-home-logger/releases/latest/download/wfh-log.exe"
            target="_blank"
            rel="noopener noreferrer"
            id="download">
              Download (Windows 🪟)
          </a>
           | 
          <a
           className="App-link"
           href="https://github.com/dylan-george-field/work-from-home-logger"
           target="_blank"
           rel="noopener noreferrer">
            Source Code (GitHub)
          </a>
        </span>
        </p>
        <h2>Installation instructions ✅</h2>
        <p>
          Download the app <br />
          Press 'Windows + R' <br />
          Type 'shell:startup' and hit OK <br />
          Paste the 'wfh-log.exe' into this folder <br />
        </p>
      </header>
      <footer>
        <a href="https://www.georgefield.com.au/contact" rel="noreferrer" target="_blank">Send feedback</a>
      </footer>
    </div>
  );
}

export default App;
