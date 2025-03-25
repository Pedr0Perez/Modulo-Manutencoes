import { memo } from "react";
import "./style/Footer.css";

const Footer = (): React.JSX.Element => {
  return <footer style={{ zIndex: "10" }}>Alpha 1.0.0</footer>;
};

export default memo(Footer);
