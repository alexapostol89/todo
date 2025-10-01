
import './App.css'
import { finalUrl } from "./baseUrl.ts";

function App() {
    return (
        <>
            <button
                className="FirstButton"
                onClick={() => {
                    fetch(finalUrl)
                        .then(response => {
                            console.log(response)
                        })
                        .catch(error => {
                            console.log(error)
                        })
                }}
            >
                cLICK ME
            </button>
            
        </>
    );
}

export default App;
