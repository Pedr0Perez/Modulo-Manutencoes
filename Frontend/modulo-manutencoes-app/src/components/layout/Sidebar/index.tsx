import { memo, useEffect, useState } from "react";
import "./style/Sidebar.css";
import opcoesSidebar from "../../../data/opcoesSidebar";
import { IOpcaoSidebar } from "../../../data/interface/IOpcaoSidebar";
import { JSX } from "@emotion/react/jsx-runtime";
import { useControleAberturaSidebar } from "../../../contexts/ControleAberturaSidebarContext";
import { SidebarAberturaEnum } from "../../../enums/SidebarAberturaEnum";
import ExpandLessIcon from "@mui/icons-material/ExpandLess";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import navigateAnchor from "../../../utils/generic/navigateAnchor";


const Sidebar = (): React.JSX.Element => {
  const { controleSidebar, setControleSidebar } = useControleAberturaSidebar();

  useEffect(() => {
   //console.log(controleSidebar);
  }, [controleSidebar]);

  useEffect(() => {
    setControleSidebar(SidebarAberturaEnum.Exibir);
  }, []);

  return (
    <div
      className={`sidebar-container${
        controleSidebar === SidebarAberturaEnum.Esconder ? " hide" : ""
      }`}
    >
      <div className="sidebar-anchor-list mt-1">
        <GerarAncorasSidebar opcoes={opcoesSidebar} key={-2} />
      </div>
    </div>
  );
};

const GerarAncorasSidebar = ({
  opcoes,
}: {
  opcoes: Array<IOpcaoSidebar>;
}): JSX.Element => {
  return (
    <>
      {opcoes.map((opcao, i) => {
        const [showItem, setShowItem] = useState(false);

        return (
          <div className="anchor-container-sidebar" key={i}>
            <div className="anchor-sidebar">
              <a
                href={opcao.href ?? undefined}
                onClick={(e: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => {
                  if (opcao.items !== null) {
                    setShowItem(!showItem);
                  }

                  if(opcao.items === null) {
                    navigateAnchor(e, opcao.href)
                  }
                }}
              >
                {
                  <div className="icon-container">
                    {opcao.icon}
                  </div>
                }
                <span className="ml-1">
                {opcao.title}
                </span>
                {opcao.items !== null && (
                  <div className="icon-container">
                    {showItem && <ExpandLessIcon />}
                    {!showItem && <ExpandMoreIcon />}
                  </div>
                )}
              </a>
            </div>
            {opcao.items !== null && (
              <div
                className={`ml-2 collapse-items-sidebar${
                  showItem ? " show" : ""
                }`}
              >
                <GerarAncorasSidebar opcoes={opcao.items!} key={opcao.id} />
              </div>
            )}
          </div>
        );
      })}
    </>
  );
};

export default memo(Sidebar);
