
import { AuctionContext } from "../../contexts/AuctionContext";
import { useContext } from "react";
import AuctionList from "../../components/AuctionList/AuctionList";

const SearchResults = () => {

    const {auctions} = useContext(AuctionContext);

    const handleSearch = () => {
        console.log("go to detailed page");
    }

    return(
        <>
        <h1>Search results</h1>
        <AuctionList auctionList={auctions} handleSearch={handleSearch} viewType="search"/>
        </>
    )
}

export default SearchResults;