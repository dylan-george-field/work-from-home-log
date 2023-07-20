import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>The work from home logbook app</h1>
        <img 
          alt="An animation showing how to set your home network in the work from home log book app."
          className="App-logo" 
          src={require("./wfh-log-animation.gif")}
        />
        <p>
          Stay Australian Tax Office (ATO) compliant. <br />
          <blockquote>
            <a href="https://www.ato.gov.au/Media-centre/Media-releases/ATO-announces-changes-to-working-from-home-deductions/"
               target="_blank"
               rel="noreferrer"
            >
            "Taxpayers need to keep a record of all the hours worked from home for the entire income year – the ATO won’t accept estimates, or a 4-week representative diary or similar document under this method from 1 March 2023"
            </a>
          </blockquote>
          Automatically record your WiFi network hourly.
          <br />
          Claim with 100% accuracy.
        </p>
        <p>
        <span>
          <a 
            className="App-link"
            href="https://github.com/dylan-george-field/work-from-home-logger/releases/latest/download/wfh-log.exe"
            target="_blank"
            rel="noopener noreferrer"
            id="download">
              Download 🪟
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
        </p>
        <p>
          <img 
            alt="A screenshot of the wfh-log app in the windows taskbar."
            src={require("./wfh-log-taskbar.png")}
          />
        </p>
        <p>Installation instructions ✅</p>
          Download the app <br />
          Press 'Windows + R' <br />
          Type 'shell:startup' and hit OK <br />
          Paste the 'wfh-log.exe' into this folder <br />
        <p>
        <img 
           alt="A scrolling animation of the work from home log using microsoft notepad."
           src={require("./wfh-log-notepad.gif")}
           className="App-logo"
        />
        </p>
      </header>
      <footer>
        <a href="https://www.georgefield.com.au/contact" rel="noreferrer" target="_blank">Send feedback</a>
      </footer>
    </div>
  );
}

export default App;
