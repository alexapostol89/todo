import './App.css'
import { useState } from "react";
import { finalUrl } from "./baseUrl.ts";

function App() {
    const [authors, setAuthors] = useState<any[]>([]);

    const handleClick = () => {
        fetch(finalUrl + "/GetAllAuthors")
            .then(response => response.json())
            .then(data => setAuthors(data))
            .catch(error => console.log(error));
    };

    return (
        <>
            <button
                className="FirstButton"
                onClick={handleClick}
            >
                cLICK ME
            </button>
            <ul>
                {authors.map(author => (
                    <li key={author.id}>
                        <div>ID: {author.id}</div>
                        <div>Name: {author.name}</div>
                        <div>Created At: {author.createdAt}</div>
                    </li>
                ))}
            </ul>
        </>
    );
}

export default App;
