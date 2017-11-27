using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data.Yahoo
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "team", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng", IsNullable = false)]
    public partial class Team
    {

        private string team_keyField;

        private byte team_idField;

        private string nameField;

        private string urlField;

        private teamTeam_logos team_logosField;

        private byte waiver_priorityField;

        private byte number_of_movesField;

        private byte number_of_tradesField;

        private teamRoster_adds roster_addsField;

        private string league_scoring_typeField;

        private byte has_draft_gradeField;

        private ushort auction_budget_totalField;

        private ushort auction_budget_spentField;

        private teamManagers managersField;

        /// <remarks/>
        public string team_key
        {
            get
            {
                return this.team_keyField;
            }
            set
            {
                this.team_keyField = value;
            }
        }

        /// <remarks/>
        public byte team_id
        {
            get
            {
                return this.team_idField;
            }
            set
            {
                this.team_idField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public teamTeam_logos team_logos
        {
            get
            {
                return this.team_logosField;
            }
            set
            {
                this.team_logosField = value;
            }
        }

        /// <remarks/>
        public byte waiver_priority
        {
            get
            {
                return this.waiver_priorityField;
            }
            set
            {
                this.waiver_priorityField = value;
            }
        }

        /// <remarks/>
        public byte number_of_moves
        {
            get
            {
                return this.number_of_movesField;
            }
            set
            {
                this.number_of_movesField = value;
            }
        }

        /// <remarks/>
        public byte number_of_trades
        {
            get
            {
                return this.number_of_tradesField;
            }
            set
            {
                this.number_of_tradesField = value;
            }
        }

        /// <remarks/>
        public teamRoster_adds roster_adds
        {
            get
            {
                return this.roster_addsField;
            }
            set
            {
                this.roster_addsField = value;
            }
        }

        /// <remarks/>
        public string league_scoring_type
        {
            get
            {
                return this.league_scoring_typeField;
            }
            set
            {
                this.league_scoring_typeField = value;
            }
        }

        /// <remarks/>
        public byte has_draft_grade
        {
            get
            {
                return this.has_draft_gradeField;
            }
            set
            {
                this.has_draft_gradeField = value;
            }
        }

        /// <remarks/>
        public ushort auction_budget_total
        {
            get
            {
                return this.auction_budget_totalField;
            }
            set
            {
                this.auction_budget_totalField = value;
            }
        }

        /// <remarks/>
        public ushort auction_budget_spent
        {
            get
            {
                return this.auction_budget_spentField;
            }
            set
            {
                this.auction_budget_spentField = value;
            }
        }

        /// <remarks/>
        public teamManagers managers
        {
            get
            {
                return this.managersField;
            }
            set
            {
                this.managersField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class teamTeam_logos
    {

        private teamTeam_logosTeam_logo team_logoField;

        /// <remarks/>
        public teamTeam_logosTeam_logo team_logo
        {
            get
            {
                return this.team_logoField;
            }
            set
            {
                this.team_logoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class teamTeam_logosTeam_logo
    {

        private string sizeField;

        private string urlField;

        /// <remarks/>
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class teamRoster_adds
    {

        private string coverage_typeField;

        private byte coverage_valueField;

        private byte valueField;

        /// <remarks/>
        public string coverage_type
        {
            get
            {
                return this.coverage_typeField;
            }
            set
            {
                this.coverage_typeField = value;
            }
        }

        /// <remarks/>
        public byte coverage_value
        {
            get
            {
                return this.coverage_valueField;
            }
            set
            {
                this.coverage_valueField = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class teamManagers
    {

        private teamManagersManager managerField;

        /// <remarks/>
        public teamManagersManager manager
        {
            get
            {
                return this.managerField;
            }
            set
            {
                this.managerField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    public partial class teamManagersManager
    {

        private byte manager_idField;

        private string nicknameField;

        private string guidField;

        /// <remarks/>
        public byte manager_id
        {
            get
            {
                return this.manager_idField;
            }
            set
            {
                this.manager_idField = value;
            }
        }

        /// <remarks/>
        public string nickname
        {
            get
            {
                return this.nicknameField;
            }
            set
            {
                this.nicknameField = value;
            }
        }

        /// <remarks/>
        public string guid
        {
            get
            {
                return this.guidField;
            }
            set
            {
                this.guidField = value;
            }
        }
    }


}
