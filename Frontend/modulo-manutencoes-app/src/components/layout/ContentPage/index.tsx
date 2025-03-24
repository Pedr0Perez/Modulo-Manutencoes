import { memo } from "react";
import { IContentPage } from "./interface/IContentPage";
import "./style/ContentPage.css";

const ContentPage = ({ children }: IContentPage): React.JSX.Element => {
  return <main className="content-page">{children}</main>;
};

export default memo(ContentPage);
