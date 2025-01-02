import { memo } from "react";
import IChildrenProps from "../../../interfaces/DefaultPage/IChildrenProps";
import "./style/MainContent.css";

const MainContent = ({ children }: IChildrenProps): JSX.Element => {
  return <main className="content-page">{children}</main>;
};

export default memo(MainContent);
