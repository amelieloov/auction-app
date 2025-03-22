import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
//import './index.css'
import App from './App.jsx'
import { BrowserRouter } from 'react-router-dom'
import AuthProvider from './contexts/AuthContext';
import UIProvider from './contexts/UIContext';
import AuctionProvider from './contexts/AuctionContext';
import BidProvider from './contexts/BidContext.jsx';
import { Toaster } from 'react-hot-toast';

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <BrowserRouter>
      <UIProvider>
        <AuthProvider>
          <AuctionProvider>
            <BidProvider>
              <App />
              <Toaster
                position="top-center"
                toastOptions={{
                  style: {
                    border: '1px solid #ccc',
                    padding: '12px',
                    color: '#333',
                  },
                  success: {
                    iconTheme: {
                      primary: '#4caf50',
                      secondary: '#fff',
                    },
                  },
                  error: {
                    iconTheme: {
                      primary: '#f44336',
                      secondary: '#fff',
                    },
                  },
                }}
              />
            </BidProvider>
          </AuctionProvider>
        </AuthProvider>
      </UIProvider>
    </BrowserRouter>
  </StrictMode>,
)
