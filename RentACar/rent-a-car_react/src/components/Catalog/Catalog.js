import CatalogItem from "./CatalogItem/CatalogItem";

const Catalog = ({ cars }) => {
    return (
        <section id="catalog-page">
            <h1>All Cars</h1>

            {cars.length > 0
                ? cars.map(x => <CatalogItem key={x.id} car={x} />)
                : <h3 className="no-articles">No cars yet</h3>
            }
        </section>
    );
};

export default Catalog;