
export const getAuctionById = async (id) => {

  const url = `https://localhost:7242/api/Auction/${id}`;

  const data = await fetch(url).then(response => response.json());

  console.log("data", data);

  return data;
}

export const searchAuctionsByName = async (condition) => {

  try {
    const response = await fetch(`https://localhost:7242/api/Auction/search?condition=${condition}`);

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const data = await response.json();

    console.log(data);

    return data;

  } catch (error) {
    console.error("Error creating auction:", error);
  }
}


export const getAuctionsByUserID = async () => {

  const data = await fetch(`https://localhost:7242/api/Auction/userId`, {
    headers: {
      "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
    },
  }).then(response => response.json());

  return data;
}

export const createAuction = async (auction) => {

  const formData = new FormData();
  formData.append("auctionTitle", auction.auctionTitle);
  formData.append("auctionDescription", auction.auctionDescription);
  formData.append("auctionPrice", auction.auctionPrice);
  formData.append("endTime", auction.endTime);
  formData.append("image", auction.image);

  console.log("auctionobject", formData)
  try {
    const response = await fetch("https://localhost:7242/api/Auction/create", {
      method: "POST",
      headers: {
        "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
      },
      body: formData
    });

    if (!response.ok) {
      const data = await response.json();
      throw new Error(data.message || "An unexpected error occurred.");
    }

  } catch (error) {
    throw(error);
  }
};

export const updateAuction = async (auction) => {

  const formData = new FormData();
  formData.append("auctionID", auction.auctionID);
  formData.append("auctionTitle", auction.auctionTitle);
  formData.append("auctionDescription", auction.auctionDescription);
  formData.append("auctionPrice", auction.auctionPrice);
  formData.append("endTime", auction.endTime);
  formData.append("image", auction.image);

  try {

    const response = await fetch(`https://localhost:7242/api/Auction/update`, {
      method: 'PUT',
      headers: {
        "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
      },
      body: formData
    })

    if (!response.ok) {
      const data = await response.json();
      throw new Error(data.message || "An unexpected error occurred.");
    }

  } catch (error) {
    throw(error);
  }
}

export const deleteAuction = async (id) => {
  try{
    const response = await fetch(`https://localhost:7242/api/Auction?auctionid=${id}`, {
      method: 'DELETE',
      headers: {
        "Authorization": `Bearer ${localStorage.getItem("AuthToken")}`,
      }
    })
  
    if (!response.ok) {
      const data = await response.json();
      throw new Error(data.message || "An unexpected error occurred.");
    }
  } catch (error){
    throw(error)
  }
}