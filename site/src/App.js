import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={require("./example.png")} className="App-logo" alt="screenshot of wfh-log" />
        <p>
          A windows app to log work from home hours for the Australian Tax Office (ATO).
        </p>
        <a
          className="App-link"
          href="https://github.com/dylan-george-field/work-from-home-logger/releases/latest/download/wfh-log-wpf.exe"
          target="_blank"
          rel="noopener noreferrer"
        >
          Download
        </a>
      </header>
    </div>
  );
}

export default App;
