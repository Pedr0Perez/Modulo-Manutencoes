import DefaultPageCard from "../../default/DefaultPageCard/DefaultPageCard";
import { memo } from "react";
import { Button } from "primereact/button";

const HomeCard = (): JSX.Element => {
  return (
    <DefaultPageCard title="Página Inicial">
      <div className="card grid">
        <div className="col-12 md:col-4 lg:col-2">
          <Button className="w-full" label="Clicar" />
        </div>
      </div>
    </DefaultPageCard>
  );
};

export default memo(HomeCard);
