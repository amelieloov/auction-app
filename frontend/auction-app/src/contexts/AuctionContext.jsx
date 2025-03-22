
import { useState, createContext } from "react";
import { useNavigate } from "react-router-dom";
import { createAuction, updateAuction, deleteAuction, searchAuctionsByName, getAuctionsByUserID } from "../services/AuctionService";
import { toast } from "react-hot-toast";

export const AuctionContext = createContext();

const AuctionProvider = (props) => {

    const navigate = useNavigate();
    const [auctions, setAuctions] = useState([]);
    const [auction, setAuction] = useState({auctionID: "", auctionTitle: "", auctionDescription: "", auctionPrice: "", 
        endTime: "", image: null
    })
    const [previewUrl, setPreviewUrl] = useState(null);
    const [searchError, setSearchError] = useState("");

    const setSearchErrorTimer = () => {
        setSearchError(true);

        setTimeout(() => {
            setSearchError(false);
        }, 3000);
    };

    const handleAddAuction = async () => {
        try {
            await createAuction(auction);
            navigate("/dashboard");
        } catch (error) {
            toast.error(error.message);
        }
    }
    
    const handleUpdateAuction = async () => {
        try {
            await updateAuction(auction);
            navigate("/dashboard");
        } catch (error) {
            toast.error(error.message);
        }
    }

    const handleSearchAuctions = async (condition) => {
        const data = await searchAuctionsByName(condition);
        setAuctions(data);
        data.length === 0 && setSearchErrorTimer();
        navigate(`/searchresults`)
    }

    const handleGetAuctionsByUser = async () => {
        const auctionList = await getAuctionsByUserID();
        setAuctions(auctionList);
    };

    const handleDeleteAuction = async (id) => {
        try {
            await deleteAuction(id);
            setAuctions((prev) => prev.filter(auction => auction.auctionID !== id));
        }
        catch (error) {
            toast.error(error.message);
        }
    }

    const checkIfClosed = (endTime) => {
        const now = new Date();
        const endTimeAsDate = new Date(endTime)
        const isClosed = endTimeAsDate < now;
        return isClosed;
    }

    return (<AuctionContext.Provider value={{
        auction, setAuction, auctions, setAuctions, searchAuctions: handleSearchAuctions, createAuction: handleAddAuction, updateAuction: handleUpdateAuction,
        deleteAuction: handleDeleteAuction, checkIfClosed, getAuctionsByUser: handleGetAuctionsByUser, searchError, setSearchErrorTimer, previewUrl, setPreviewUrl
    }}>
        {props.children}
    </AuctionContext.Provider>)
}

export default AuctionProvider;