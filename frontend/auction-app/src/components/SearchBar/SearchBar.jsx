import { useState, useContext } from "react"
import './SearchBar.css'
import { AuctionContext } from "../../contexts/AuctionContext";

const SearchBar = () => {

    const [inputValue, setInputValue] = useState("");
    const {searchAuctions, searchError} = useContext(AuctionContext);

    const onSearch = (e) => {
        if(e.key === "Enter"){
            searchAuctions(inputValue);
            setInputValue("");
        }
    }

    const onChange = (e) => {
        setInputValue(e.target.value);
    }

    return(
        <input className="search-bar" type="text" value={inputValue} onChange={onChange} onKeyDown={onSearch}
        placeholder= {searchError ? "No results" : "Search auctions..."}/>
    )
}

export default SearchBar;