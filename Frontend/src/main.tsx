import { createRoot } from "react-dom/client";
import App from "./App.tsx";

const startApplication = (): void => {
  createRoot(document.getElementById("application")!).render(<App />);
};

startApplication();
