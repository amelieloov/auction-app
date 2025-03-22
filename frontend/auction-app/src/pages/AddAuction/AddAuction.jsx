
import { useContext, useEffect } from "react"
import AuctionForm from "../../components/AuctionForm/AuctionForm";
import { AuctionContext } from "../../contexts/AuctionContext";

const AddAuction = () => {

    const {setAuction, createAuction} = useContext(AuctionContext);

    useEffect(() => {
        setAuction({auctionID: "", auctionTitle: "", auctionDescription: "", auctionPrice: "", 
            endTime: "", image: null })
    }, [])

    return(
        <AuctionForm rubric="Create auction" buttonText="Post" handleSubmit={createAuction}/>
    )
}

export default AddAuction;