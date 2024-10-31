import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";
import { FetchProvider } from "./contexts/fetch.context.jsx";

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <FetchProvider>
      <App />
    </FetchProvider>
  </StrictMode>
);
