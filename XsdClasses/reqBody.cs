﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/ship/rate-v4")]
[System.Xml.Serialization.XmlRootAttribute("mailing-scenario", Namespace="http://www.canadapost.ca/ws/ship/rate-v4", IsNullable=false)]
public partial class mailingscenario {
    
    private string quotetypeField;
    
    private mailingscenarioParcelcharacteristics parcelcharacteristicsField;
    
    private string originpostalcodeField;
    
    private mailingscenarioDestination destinationField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("quote-type")]
    public string quotetype {
        get {
            return this.quotetypeField;
        }
        set {
            this.quotetypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("parcel-characteristics")]
    public mailingscenarioParcelcharacteristics parcelcharacteristics {
        get {
            return this.parcelcharacteristicsField;
        }
        set {
            this.parcelcharacteristicsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("origin-postal-code")]
    public string originpostalcode {
        get {
            return this.originpostalcodeField;
        }
        set {
            this.originpostalcodeField = value;
        }
    }
    
    /// <remarks/>
    public mailingscenarioDestination destination {
        get {
            return this.destinationField;
        }
        set {
            this.destinationField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/ship/rate-v4")]
public partial class mailingscenarioParcelcharacteristics {
    
    private byte weightField;
    
    /// <remarks/>
    public byte weight {
        get {
            return this.weightField;
        }
        set {
            this.weightField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/ship/rate-v4")]
public partial class mailingscenarioDestination {
    
    private mailingscenarioDestinationDomestic domesticField;
    
    /// <remarks/>
    public mailingscenarioDestinationDomestic domestic {
        get {
            return this.domesticField;
        }
        set {
            this.domesticField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.canadapost.ca/ws/ship/rate-v4")]
public partial class mailingscenarioDestinationDomestic {
    
    private string postalcodeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("postal-code")]
    public string postalcode {
        get {
            return this.postalcodeField;
        }
        set {
            this.postalcodeField = value;
        }
    }
}
