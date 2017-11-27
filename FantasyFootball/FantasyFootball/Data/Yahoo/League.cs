using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FantasyFootball.Data.Yahoo
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng")]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "league", Namespace = "http://fantasysports.yahooapis.com/fantasy/v2/base.rng", IsNullable = false)]
    public partial class League
    {

        //private string league_keyField;

        //private uint league_idField;

        //private string nameField;

        //private string urlField;

        //private string draft_statusField;

        private byte num_teamsField;

        //private System.DateTime edit_keyField;

        //private string weekly_deadlineField;

        //private uint league_update_timestampField;

        //private string scoring_typeField;

        //private string league_typeField;

        //private object renewField;

        //private object renewedField;

        //private byte allow_add_to_dl_extra_posField;

        //private byte is_pro_leagueField;

        //private byte is_cash_leagueField;

        //private System.DateTime start_dateField;

        //private System.DateTime end_dateField;

        //private byte is_finishedField;

        //private string game_codeField;

        //private ushort seasonField;

        ///// <remarks/>
        //public string league_key
        //{
        //    get
        //    {
        //        return this.league_keyField;
        //    }
        //    set
        //    {
        //        this.league_keyField = value;
        //    }
        //}

        ///// <remarks/>
        //public uint league_id
        //{
        //    get
        //    {
        //        return this.league_idField;
        //    }
        //    set
        //    {
        //        this.league_idField = value;
        //    }
        //}

        ///// <remarks/>
        //public string name
        //{
        //    get
        //    {
        //        return this.nameField;
        //    }
        //    set
        //    {
        //        this.nameField = value;
        //    }
        //}

        ///// <remarks/>
        //public string url
        //{
        //    get
        //    {
        //        return this.urlField;
        //    }
        //    set
        //    {
        //        this.urlField = value;
        //    }
        //}

        ///// <remarks/>
        //public string draft_status
        //{
        //    get
        //    {
        //        return this.draft_statusField;
        //    }
        //    set
        //    {
        //        this.draft_statusField = value;
        //    }
        //}

        /// <remarks/>
        [XmlElement(ElementName = "num_teams")]
        public byte NumTeams
        {
            get
            {
                return this.num_teamsField;
            }
            set
            {
                this.num_teamsField = value;
            }
        }

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        //public System.DateTime edit_key
        //{
        //    get
        //    {
        //        return this.edit_keyField;
        //    }
        //    set
        //    {
        //        this.edit_keyField = value;
        //    }
        //}

        ///// <remarks/>
        //public string weekly_deadline
        //{
        //    get
        //    {
        //        return this.weekly_deadlineField;
        //    }
        //    set
        //    {
        //        this.weekly_deadlineField = value;
        //    }
        //}

        ///// <remarks/>
        //public uint league_update_timestamp
        //{
        //    get
        //    {
        //        return this.league_update_timestampField;
        //    }
        //    set
        //    {
        //        this.league_update_timestampField = value;
        //    }
        //}

        ///// <remarks/>
        //public string scoring_type
        //{
        //    get
        //    {
        //        return this.scoring_typeField;
        //    }
        //    set
        //    {
        //        this.scoring_typeField = value;
        //    }
        //}

        ///// <remarks/>
        //public string league_type
        //{
        //    get
        //    {
        //        return this.league_typeField;
        //    }
        //    set
        //    {
        //        this.league_typeField = value;
        //    }
        //}

        ///// <remarks/>
        //public object renew
        //{
        //    get
        //    {
        //        return this.renewField;
        //    }
        //    set
        //    {
        //        this.renewField = value;
        //    }
        //}

        ///// <remarks/>
        //public object renewed
        //{
        //    get
        //    {
        //        return this.renewedField;
        //    }
        //    set
        //    {
        //        this.renewedField = value;
        //    }
        //}

        ///// <remarks/>
        //public byte allow_add_to_dl_extra_pos
        //{
        //    get
        //    {
        //        return this.allow_add_to_dl_extra_posField;
        //    }
        //    set
        //    {
        //        this.allow_add_to_dl_extra_posField = value;
        //    }
        //}

        ///// <remarks/>
        //public byte is_pro_league
        //{
        //    get
        //    {
        //        return this.is_pro_leagueField;
        //    }
        //    set
        //    {
        //        this.is_pro_leagueField = value;
        //    }
        //}

        ///// <remarks/>
        //public byte is_cash_league
        //{
        //    get
        //    {
        //        return this.is_cash_leagueField;
        //    }
        //    set
        //    {
        //        this.is_cash_leagueField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        //public System.DateTime start_date
        //{
        //    get
        //    {
        //        return this.start_dateField;
        //    }
        //    set
        //    {
        //        this.start_dateField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        //public System.DateTime end_date
        //{
        //    get
        //    {
        //        return this.end_dateField;
        //    }
        //    set
        //    {
        //        this.end_dateField = value;
        //    }
        //}

        ///// <remarks/>
        //public byte is_finished
        //{
        //    get
        //    {
        //        return this.is_finishedField;
        //    }
        //    set
        //    {
        //        this.is_finishedField = value;
        //    }
        //}

        ///// <remarks/>
        //public string game_code
        //{
        //    get
        //    {
        //        return this.game_codeField;
        //    }
        //    set
        //    {
        //        this.game_codeField = value;
        //    }
        //}

        ///// <remarks/>
        //public ushort season
        //{
        //    get
        //    {
        //        return this.seasonField;
        //    }
        //    set
        //    {
        //        this.seasonField = value;
        //    }
        //}
    }
}
