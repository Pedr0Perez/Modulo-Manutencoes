import { memo, useContext, useEffect, useState } from "react";
import "./style/Sidebar.css";
import opcoesSidebar from "../../../data/opcoesSidebar";
import { IOpcaoSidebar } from "../../../data/interface/IOpcaoSidebar";
import { JSX } from "@emotion/react/jsx-runtime";
import { ControleAberturaSidebarContext } from "../../../contexts/ControleAberturaSidebarContext";
import { useControleAberturaSidebar } from "../../../contexts/ControleAberturaSidebarContext";
import { SidebarAberturaEnum } from "../../../enums/SidebarAberturaEnum";

const Sidebar = (): React.JSX.Element => {
  const { controleSidebar, setControleSidebar } = useControleAberturaSidebar();

  useEffect(() => {
    setControleSidebar(SidebarAberturaEnum.Exibir);
  }, []);

  return (
    <div
      className={`sidebar-container${
        controleSidebar === SidebarAberturaEnum.Esconder ? " hide" : ""
      }`}
    >
      <div className="sidebar-anchor-list">
        <GerarAncorasSidebar opcoes={opcoesSidebar} collapse={false} />
      </div>
    </div>
  );
};

const GerarAncorasSidebar = ({
  opcoes,
  collapse = false,
}: {
  opcoes: Array<IOpcaoSidebar>;
  collapse: boolean;
}): JSX.Element => {
  return (
    <>
      {opcoes.map((opcao, i) => {
        const [showItem, setShowItem] = useState(false);

        return (
          <div className="anchor-container-sidebar">
            <div className="anchor-sidebar">
              <a
                href={opcao.href ?? "#"}
                onClick={() => {
                  if (opcao.items !== null) {
                    setShowItem(!showItem);
                  }
                }}
              >
                {opcao.title}
              </a>
            </div>
            {opcao.items !== null && (
              <div
                className={`ml-2 collapse-items-sidebar${
                  showItem ? " show" : ""
                }`}
              >
                <GerarAncorasSidebar opcoes={opcao.items!} collapse={true} />
              </div>
            )}
          </div>
        );
      })}
    </>
  );
};

export default memo(Sidebar);
