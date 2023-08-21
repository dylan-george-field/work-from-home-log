import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>work from home log</h1>
        <img 
           alt="A scrolling animation of the work from home log using microsoft notepad."
           src={require("./wfh-log-demo.gif")}
           className="App-logo"
        />
        <p>
          <blockquote>
            <a 
                className="App-link"
                href="https://www.ato.gov.au/Media-centre/Media-releases/ATO-announces-changes-to-working-from-home-deductions/"
                target="_blank"
                rel="noreferrer"
            >
            "Taxpayers need to keep a record of all the hours worked from home for the entire income year – the Australian Tax Office (ATO) won’t accept estimates, or a 4-week representative diary or similar document under this method from 1 March 2023"
            </a>
          </blockquote>
          Automatically record your WiFi network hourly.
          <br />
          Claim with 100% accuracy.
          <br />
          Stay compliant.
        </p>
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
          alt="An animation showing how to set your home network in the work from home log book app."
          className="App-logo" 
          src={require("./wfh-log-animation.gif")}
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
