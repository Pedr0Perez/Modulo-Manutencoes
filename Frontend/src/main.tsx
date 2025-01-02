import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import "./style/main.css";
import "primereact/resources/themes/lara-light-blue/theme.css";
import "/node_modules/primeflex/primeflex.css";

const startApplication = (): void => {
  createRoot(document.getElementById("application")!).render(<App />);
  return;
};

startApplication();
