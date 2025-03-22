
import { useState, useContext, createContext } from "react";
import { addBid, deleteBid, getBidsByUserID } from "../services/BidService";
import { getAuctionById } from "../services/AuctionService";
import { AuctionContext } from "./AuctionContext";
import { toast } from 'react-hot-toast';

export const BidContext = createContext();

const BidProvider = (props) => {

    const [bids, setBids] = useState([]);
    const {setAuction} = useContext(AuctionContext);

    const handleGetBidsByUser = async () => {     
        const bidList = await getBidsByUserID();
        setBids(bidList);
    }

    const handleAddBid = async (newBid) => {
        try {
            await addBid(newBid);
            const auction = await getAuctionById(newBid.auctionID);
            setAuction(auction);
            setBids(auction.bids);
        } catch (error) {
            toast.error(error.message);
        }
    };

    const handleDeleteBid = async (bidId) => {
        try {
            await deleteBid(bidId);
            await handleGetBidsByUser();
        } catch (error) {
            toast.error(error.message);
        }
    }

    return (<BidContext.Provider value={{ bids, setBids, addBid: handleAddBid, deleteBid: handleDeleteBid, getBidsByUser: handleGetBidsByUser}}>
        {props.children}
    </BidContext.Provider>)
}

export default BidProvider;