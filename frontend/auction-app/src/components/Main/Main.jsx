
import {Routes, Route} from 'react-router-dom';
import Home from '../../pages/Home/Home';
import Dashboard from '../../pages/Dashboard/Dashboard';
import DetailedAuctionInfo from '../../pages/DetailedAuctionInfo/DetailedAuctionInfo';
import AddAuction from '../../pages/AddAuction/AddAuction';
import UpdateAuction from '../../pages/UpdateAuction/UpdateAuction';
import SearchResults from '../../pages/SearchResults/SearchResults';

const Main = () => {

    return(
        <Routes>
            <Route path="/" element={<Home/>}></Route>
            <Route path="/dashboard" element={<Dashboard/>}></Route>
            <Route path="/item/:id" element={<DetailedAuctionInfo/>}></Route>
            <Route path="/auction/add" element={<AddAuction/>}></Route>
            <Route path="/auction/update/:id" element={<UpdateAuction/>}></Route>
            <Route path="/searchresults" element={<SearchResults/>}></Route>
        </Routes>
    )
}

export default Main;